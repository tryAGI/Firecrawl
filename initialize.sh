dotnet tool install --global autosdk.cli --prerelease

autosdk init \
  Firecrawl \
  FirecrawlApp \
  https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/openapi.json \
  tryAGI \
  --output .