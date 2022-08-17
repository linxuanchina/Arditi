namespace Arditi.Application;

public interface IRequestHandler<in TRequest, TResponse> : MediatR.IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
}

public abstract class RequestHandler<TRequest> : IRequestHandler<TRequest, Response>
    where TRequest : IRequest
{
    public async Task<Response> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await InnerHandle(request, cancellationToken).ConfigureAwait(false);
        return new Response();
    }

    protected abstract Task InnerHandle(TRequest request, CancellationToken cancellationToken);
}

public abstract class ItemRequestHandler<TRequest, TItem> : IRequestHandler<TRequest, ItemResponse<TItem>>
    where TRequest : IItemRequest<TItem>
{
    public async Task<ItemResponse<TItem>> Handle(TRequest request, CancellationToken cancellationToken) =>
        new(await InnerHandle(request, cancellationToken).ConfigureAwait(false));

    protected abstract Task<TItem> InnerHandle(TRequest request, CancellationToken cancellationToken);
}

public abstract class ItemsRequestHandler<TRequest, TItem> : IRequestHandler<TRequest, ItemsResponse<TItem>>
    where TRequest : IItemsRequest<TItem>
    where TItem : notnull
{
    public async Task<ItemsResponse<TItem>> Handle(TRequest request, CancellationToken cancellationToken) =>
        new(await InnerHandle(request, cancellationToken).ConfigureAwait(false));

    protected abstract Task<IEnumerable<TItem>> InnerHandle(TRequest request, CancellationToken cancellationToken);
}

public abstract class
    RequestPaginationHandler<TRequest, TItem> : IRequestHandler<TRequest, PaginationResponse<TItem>>
    where TRequest : IPagedListRequest<TItem>
    where TItem : notnull
{
    public async Task<PaginationResponse<TItem>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var (total, items) = await InnerHandle(request, cancellationToken).ConfigureAwait(false);
        return new PaginationResponse<TItem>(items, request.Pagination with { Total = total });
    }

    protected abstract Task<(int total, IEnumerable<TItem> items)> InnerHandle(TRequest request,
        CancellationToken cancellationToken);
}
