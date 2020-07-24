using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Toxic.EventBus
{
    public abstract class RequestHandler<TRequest> : IRequestHandler<TRequest, Response>
        where TRequest : IRequest
    {
        public abstract Task<Response> Handle(TRequest request, CancellationToken cancellationToken);

        public Response Succeed(string message = "")
        {
            return new Response { Successful = true, Message = message };
        }

        public Response Failed(string message = "")
        {
            return new Response { Successful = false, Message = message };
        }
    }
}