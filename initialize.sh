dotnet tool install --global openapigenerator.cli --prerelease

oag init \
  Firecrawl \
  FirecrawlApp \
  https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/openapi.json \
  tryAGI \
  --output .