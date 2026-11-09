#!/usr/bin/env bash
set -euo pipefail

install_autosdk_cli() {
  dotnet tool update --global autosdk.cli --prerelease >/dev/null 2>&1 || \
    dotnet tool install --global autosdk.cli --prerelease
}

fetch_spec() {
  curl "$@" \
    --fail --silent --show-error --location \
    --retry 5 --retry-delay 10 --retry-all-errors \
    --connect-timeout 30 --max-time 300
}

# OpenAPI spec: https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json

use_pinned_spec=false
for arg in "$@"; do
  case "$arg" in
    --pinned-spec)
      use_pinned_spec=true
      ;;
    *)
      echo "Unknown argument: $arg" >&2
      exit 1
      ;;
  esac
done
if [[ "${TRYAGI_PINNED_SPEC:-0}" == "1" ]]; then
  use_pinned_spec=true
fi
# --reject-unknown-enum-values below is only safe once AutoSDK narrows it to enums that cannot appear
# in a response. An older autosdk.cli accepts the flag and hardens every enum, including task status
# and, here, the one-value `status: "cancelled"` that DELETE /crawl/{id} answers with — which would
# throw on a successful cancel the day that wording changes.
#
# The floor is measured rather than guessed, and has moved once already: .171 narrowed the opt-in but
# still hardened one-value response enums, which 0.35.0-preview.2.176 fixed. Each build reports the
# commit it came from, e.g. 0.35.0-preview.2.176+fa115c6a21..., which is how both floors were pinned.
# 0.35.0-preview.2.170 was the newest published version whose
# `generate --help` does not describe the narrowing, and AutoSDK's main is linear with a monotonic
# MinVer height, so anything above it contains the fix. 0.35.0-preview.2.170 reports itself as built
# from 4e5f2e105c, the commit immediately before the narrowing landed, which pins the floor exactly. The help-text probe is kept as a backstop in
# case a build ever lands out of order. Failing here is the safe outcome; regenerating with the wrong
# behaviour is not.
AUTOSDK_MIN_VERSION="0.35.0-preview.2.176"

compare_autosdk_version() {
  python3 - "$1" "$2" <<'PYVER'
import re, sys

def key(text):
    match = re.fullmatch(r"(\d+)\.(\d+)\.(\d+)(?:-preview\.(\d+)\.(\d+))?", text.strip())
    if match is None:
        raise SystemExit(2)
    major, minor, patch, series, height = match.groups()
    # A stable release outranks any preview of the same version.
    return (int(major), int(minor), int(patch), 1 if series is None else 0,
            int(series or 0), int(height or 0))

sys.exit(0 if key(sys.argv[1]) >= key(sys.argv[2]) else 1)
PYVER
}

require_direction_aware_enum_rejection() {
  # `autosdk --version` is the source rather than `dotnet tool list --global`, which aborts outright on
  # this machine ("'adv' is not a valid version string") because one unrelated global tool breaks the
  # whole listing. The reported version also carries the build's commit, e.g.
  # 0.35.0-preview.2.170+4e5f2e105c..., which is how the floor below was confirmed; strip that suffix.
  local installed
  installed=$(autosdk --version 2>/dev/null | head -n 1 | cut -d+ -f1)

  # Fail closed: a missing or unparseable version stops the regeneration rather than assuming the best.
  if ! compare_autosdk_version "$installed" "$AUTOSDK_MIN_VERSION"; then
    echo "error: autosdk.cli ${installed:-<not installed>} does not meet the required $AUTOSDK_MIN_VERSION," >&2
    echo "       the first version that narrows --reject-unknown-enum-values to request-reachable enums correctly." >&2
    echo "       Run: dotnet tool update --global autosdk.cli --prerelease" >&2
    exit 1
  fi

  if ! autosdk generate --help 2>&1 | grep -q 'request-reachable enums only'; then
    echo "error: autosdk.cli $installed satisfies the version floor but does not describe the narrowing" >&2
    echo "       of --reject-unknown-enum-values. Refusing to harden response enums." >&2
    exit 1
  fi
}

install_autosdk_cli
require_direction_aware_enum_rejection
rm -rf Generated
if [[ "$use_pinned_spec" == false ]]; then
  fetch_spec --fail --silent --show-error -L -o openapi.json https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json
elif [[ ! -f openapi.json ]]; then
  echo "error: --pinned-spec requested but openapi.json does not exist." >&2
  exit 1
fi

# Fix metadata description field: Firecrawl API can return string or string[]
# See: https://github.com/tryAGI/Firecrawl/issues/54
python3 -c "
import json
with open('openapi.json', 'r') as f:
    spec = json.load(f)

def fix_metadata_description(obj):
    if isinstance(obj, dict):
        props = obj.get('properties', {})
        # Only target metadata objects (identified by having title + sourceURL siblings)
        if 'title' in props and 'sourceURL' in props and 'description' in props:
            desc = props['description']
            if isinstance(desc, dict) and desc.get('type') == 'string' and 'oneOf' not in desc:
                props['description'] = {
                    'oneOf': [
                        {'type': 'string'},
                        {'type': 'array', 'items': {'type': 'string'}}
                    ]
                }
        for v in obj.values():
            fix_metadata_description(v)
    elif isinstance(obj, list):
        for v in obj:
            fix_metadata_description(v)

fix_metadata_description(spec)
with open('openapi.json', 'w') as f:
    json.dump(spec, f, indent=2)
"

autosdk generate openapi.json \
  --namespace Firecrawl \
  --clientClassName FirecrawlClient \
  --targetFramework net10.0 \
  --output Generated \
  --reject-unknown-enum-values \
  --exclude-deprecated-operations \
  --generate-http-exception-hierarchy \
  --generate-idempotency-helpers \
  --idempotency-header-name x-idempotency-key \
  --generate-retry-handler \
  --generate-pageable-helpers \
  --generate-multipart-upload-helpers

rm -rf ../Firecrawl.Cli/GeneratedApi
autosdk cli-project openapi.json \
  --output ../Firecrawl.Cli/GeneratedApi \
  --api-only \
  --sdk-project ../Firecrawl/Firecrawl.csproj \
  --targetFramework net10.0 \
  --namespace Firecrawl \
  --clientClassName FirecrawlClient \
  --package-id Firecrawl.Cli.GeneratedApi \
  --root-namespace Firecrawl.Cli.GeneratedApi \
  --tool-command-name firecrawl \
  --user-secrets-id Firecrawl.Cli \
  --api-key-env-var FIRECRAWL_API_KEY \
  --base-url-env-var FIRECRAWL_BASE_URL \
  --cli-credential-file \
  --cli-keep-api-group \
  --exclude-deprecated-operations
