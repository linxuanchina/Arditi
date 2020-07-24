using MediatR;

namespace Toxic.EventBus
{
    public interface IListRequest<TResponseItem> : IRequest<ListResponse<TResponseItem>> { }
}