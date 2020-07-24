using MediatR;

namespace Toxic.EventBus
{
    public interface IObjectRequest<TResponse> : IRequest<ObjectResponse<TResponse>> { }
}