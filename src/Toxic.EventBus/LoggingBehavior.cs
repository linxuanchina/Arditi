using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Toxic.EventBus
{
    public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            Log.Information("Handling {@0}", request);
            var response = await next();
            Log.Information("Handled {@0}", response);
            return response;
        }
    }
}