using System.Net.Http;

namespace Firecrawl;

public sealed partial class FirecrawlClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class BillingClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class CrawlingClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class ExtractionClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class LLMsTxtClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class MappingClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class ResearchClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class ScrapingClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}

public partial class SearchClient
{
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        => FirecrawlExceptionMapper.ThrowTypedFirecrawlException(response);
}
