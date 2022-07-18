using System.Diagnostics;
using Serilog;
using Serilog.Events;

namespace Arditi.Application;

public sealed class ApplicationPipelineBehavior<TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    private static readonly ILogger s_logger = Log.ForContext<ApplicationPipelineBehavior<TRequest, TResponse>>();

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        MediatR.RequestHandlerDelegate<TResponse> next)
    {
        var enabledLogging = s_logger.IsEnabled(LogEventLevel.Information);

        var stopwatch = Stopwatch.StartNew();

        if (enabledLogging)
        {
            s_logger
                .ForContext("Request", request)
                .Information("Request handling");
        }

        TResponse? response = null;

        try
        {
            response = await next().ConfigureAwait(false);
        }
        catch (ApplicationException exception)
        {
            response = (TResponse)new Response(exception);
        }
        finally
        {
            stopwatch.Stop();

            if (enabledLogging)
            {
                s_logger
                    .ForContext("Request", request)
                    .ForContext("Response", response)
                    .Information("Request handled ({ElapsedMilliseconds}ms)",
                        stopwatch.ElapsedMilliseconds);
            }
        }

        return response;
    }
}
