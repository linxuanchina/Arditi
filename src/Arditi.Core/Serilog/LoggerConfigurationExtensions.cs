using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace Serilog;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration EnrichFromLogContext(this LoggerConfiguration configuration) =>
        configuration.Enrich.FromLogContext();

    public static LoggerConfiguration EnrichWithExceptionDetails(this LoggerConfiguration configuration,
        Action<DestructuringOptionsBuilder>? configureDestructuring = null)
    {
        var builder = new DestructuringOptionsBuilder();
        configureDestructuring?.Invoke(builder);
        return configuration.Enrich.WithExceptionDetails(builder);
    }
}
