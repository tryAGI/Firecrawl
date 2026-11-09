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
# --reject-unknown-enum-values is only safe on a build that narrows it to enums which cannot appear in
# a response; an older one accepts the flag and hardens every enum, so ordinary replies start throwing.
# `autosdk capabilities --require` asks the build itself, which replaces both a version floor (had to be
# looked up after each publish, and moved once already) and a grep over help-text prose. A CLI without
# the subcommand fails the call, so this is fail-closed.
require_autosdk_capability() {
  if ! autosdk capabilities --require "$1" >/dev/null 2>&1; then
    echo "error: this autosdk.cli does not support '$1'." >&2
    echo "       Run: dotnet tool update --global autosdk.cli --prerelease" >&2
    exit 1
  fi
}

install_autosdk_cli
require_autosdk_capability behavior:request-scoped-enum-rejection
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
