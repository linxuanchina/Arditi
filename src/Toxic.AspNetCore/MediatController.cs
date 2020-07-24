using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Toxic.AspNetCore
{
    public class MediatController : Controller
    {
        private readonly IMediator _mediator;

        protected MediatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [NonAction]
        protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [NonAction]
        protected Task Publish(INotification notification, CancellationToken cancellationToken = default)
        {
            return _mediator.Publish(notification, cancellationToken);
        }
    }
}