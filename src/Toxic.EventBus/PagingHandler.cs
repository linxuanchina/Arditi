using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Toxic.EventBus
{
    public abstract class PagingHandler<TRequest, TResponseItem> : IRequestHandler<TRequest, PagingResponse<TResponseItem>>
        where TRequest : IPagingRequest<TResponseItem>
    {
        public abstract Task<PagingResponse<TResponseItem>> Handle(TRequest request,
            CancellationToken cancellationToken);

        public PagingResponse<TResponseItem> Succeed(int total, IEnumerable<TResponseItem> response)
        {
            return new PagingResponse<TResponseItem> { Total = total, Successful = true, Response = response };
        }

        public PagingResponse<TResponseItem> Succeed(int total, IEnumerable<TResponseItem> response, string message)
        {
            return new PagingResponse<TResponseItem> { Total = total, Successful = true, Response = response, Message = message };
        }

        public PagingResponse<TResponseItem> Failed(string message)
        {
            return new PagingResponse<TResponseItem> { Successful = false, Message = message };
        }

        public PagingResponse<TResponseItem> Failed(int total, IEnumerable<TResponseItem> response, string message)
        {
            return new PagingResponse<TResponseItem> { Total = total, Successful = false, Response = response, Message = message };
        }
    }
}