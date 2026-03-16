dotnet tool install --global autosdk.cli --prerelease

autosdk init \
  Firecrawl \
  FirecrawlClient \
  https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/openapi.json \
  tryAGI \
  --output .
