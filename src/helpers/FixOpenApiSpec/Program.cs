using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

var path = args[0];
var text = await File.ReadAllTextAsync(path);

var openApiDocument = new OpenApiStringReader().Read(text, out var diagnostics);

openApiDocument.Paths["/crawl/{id}"]!
    .Operations[OperationType.Get]!
    .Parameters.Add(new OpenApiParameter
    {
        Name = "id",
        In = ParameterLocation.Path,
        Required = true,
        Schema = new OpenApiSchema
        {
            Type = "string"
        }
    });

text = openApiDocument.SerializeAsYaml(OpenApiSpecVersion.OpenApi3_0);
_ = new OpenApiStringReader().Read(text, out diagnostics);

if (diagnostics.Errors.Count > 0)
{
    foreach (var error in diagnostics.Errors)
    {
        Console.WriteLine(error.Message);
    }
    // Return Exit code 1
    Environment.Exit(1);
}

await File.WriteAllTextAsync(path, text);
return;