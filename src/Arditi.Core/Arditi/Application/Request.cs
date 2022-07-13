namespace Arditi.Application;

public interface IRequest<out TResponse> : MediatR.IRequest<TResponse> where TResponse : Response
{
}

public interface IRequest : IRequest<Response>
{
}

public interface IItemRequest<TItem> : IRequest<ItemResponse<TItem>>
{
}

public interface IItemsRequest<TItem> : IRequest<ItemsResponse<TItem>> where TItem : notnull
{
}

public interface IPaginationRequest<TItem> : IRequest<PaginationResponse<TItem>> where TItem : notnull
{
    Pagination Pagination { get; set; }
}
