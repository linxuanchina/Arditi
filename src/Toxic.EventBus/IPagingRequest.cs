using MediatR;

namespace Toxic.EventBus
{
    public interface IPagingRequest<TResponseItem> : IRequest<PagingResponse<TResponseItem>>
    {
        int Index { get; set; }

        int Size { get; set; }
    }
}