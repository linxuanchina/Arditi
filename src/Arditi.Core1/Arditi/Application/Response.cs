namespace Arditi.Application;

public record Response(ArditiException? Error = null)
{
    public bool Successful => Error.IsNull();
}

public sealed record ItemResponse<TItem>(TItem? Item) : Response;

public record ItemsResponse<TItem>(IEnumerable<TItem>? Items) : Response where TItem : notnull;

public sealed record PaginationResponse<TItem>
    (IEnumerable<TItem>? Items, Pagination? Pagination) : ItemsResponse<TItem>(Items)
    where TItem : notnull;
