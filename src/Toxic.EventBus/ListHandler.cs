using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Toxic.EventBus
{
    public abstract class ListHandler<TRequest, TResponseItem> : IRequestHandler<TRequest, ListResponse<TResponseItem>>
        where TRequest : IListRequest<TResponseItem>
    {
        public abstract Task<ListResponse<TResponseItem>> Handle(TRequest request, CancellationToken cancellationToken);

        public ListResponse<TResponseItem> Succeed(IEnumerable<TResponseItem> response)
        {
            return new ListResponse<TResponseItem> { Successful = true, Response = response };
        }

        public ListResponse<TResponseItem> Succeed(IEnumerable<TResponseItem> response, string message)
        {
            return new ListResponse<TResponseItem> { Successful = true, Response = response, Message = message };
        }

        public ListResponse<TResponseItem> Failed(string message)
        {
            return new ListResponse<TResponseItem> { Successful = false, Message = message };
        }

        public ListResponse<TResponseItem> Failed(IEnumerable<TResponseItem> response, string message)
        {
            return new ListResponse<TResponseItem> { Successful = false, Response = response, Message = message };
        }
    }
}