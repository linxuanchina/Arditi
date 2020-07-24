using MediatR;

namespace Toxic.EventBus
{
    public interface IRequest : IRequest<Response> { }
}