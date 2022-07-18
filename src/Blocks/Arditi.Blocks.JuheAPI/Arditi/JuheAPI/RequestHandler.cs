namespace Arditi.JuheAPI;

public sealed class RequestHandler : DelegatingHandler
{
    private readonly JuheApiOptions _options;

    public RequestHandler(JuheApiOptions options)
    {
        _options = options;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.RequestUri != null)
        {
            var query = $"key={_options.Key}";

            var builder = new UriBuilder(request.RequestUri);
            if (request.RequestUri.Query.IsNullOrWhiteSpace())
            {
                builder.Query = $"?{query}";
            }
            else
            {
                builder.Query += $"&{query}";
            }

            request.RequestUri = builder.Uri;
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
