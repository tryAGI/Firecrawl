dotnet tool install --global openapigenerator.cli --prerelease
rm -rf Generated
curl -o openapi.yaml https://raw.githubusercontent.com/mendableai/firecrawl/main/apps/api/openapi.json
dotnet run --project ../../helpers/FixOpenApiSpec openapi.yaml
if [ $? -ne 0 ]; then
 echo "Failed, exiting..."
 exit 1
fi
oag generate openapi.yaml \
  --namespace Firecrawl \
  --clientClassName FirecrawlApp \
  --targetFramework net8.0 \
  --output Generated \
  --exclude-deprecated-operations