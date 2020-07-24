using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Toxic.EventBus
{
    public abstract class ObjectHandler<TRequest, TResponse> : IRequestHandler<TRequest, ObjectResponse<TResponse>>
        where TRequest : IObjectRequest<TResponse>
    {
        public abstract Task<ObjectResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

        public ObjectResponse<TResponse> Succeed(TResponse response)
        {
            return new ObjectResponse<TResponse> { Successful = true, Response = response };
        }

        public ObjectResponse<TResponse> Succeed(TResponse response, string message)
        {
            return new ObjectResponse<TResponse> { Successful = true, Response = response, Message = message };
        }

        public ObjectResponse<TResponse> Failed(string message)
        {
            return new ObjectResponse<TResponse> { Successful = false, Message = message };
        }

        public ObjectResponse<TResponse> Failed(TResponse response, string message)
        {
            return new ObjectResponse<TResponse> { Successful = false, Response = response, Message = message };
        }
    }
}