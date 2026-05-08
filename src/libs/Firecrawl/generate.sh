#!/usr/bin/env bash
set -euo pipefail

# OpenAPI spec: https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json

dotnet tool install --global autosdk.cli --prerelease
rm -rf Generated
curl --fail --silent --show-error -L -o openapi.json https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json

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
  --exclude-deprecated-operations
