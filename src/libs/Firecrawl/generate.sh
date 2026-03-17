set -e
dotnet tool install --global autosdk.cli --prerelease
rm -rf Generated
curl --fail --silent --show-error -o openapi.json https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/v1-openapi.json
autosdk generate openapi.json \
  --namespace Firecrawl \
  --clientClassName FirecrawlClient \
  --targetFramework net8.0 \
  --output Generated \
  --exclude-deprecated-operations
