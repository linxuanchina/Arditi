using Serilog;
using Serilog.Configuration;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;

namespace Arditi.WebHost;

public sealed class LoggerSettings : ILoggerSettings
{
    private readonly HostBuilderContext _context;

    public LoggerSettings(HostBuilderContext context)
    {
        _context = context;
    }

    public void Configure(LoggerConfiguration configuration)
    {
        configuration.MinimumLevel.Debug()
            .OverrideMicrosoftAspNetCoreToWarning()
            .EnrichFromLogContext()
            .EnrichWithExceptionDetails(builder =>
            {
                builder
                    .WithDefaultDestructurers()
                    .WithDestructurers(new[] { new DbUpdateExceptionDestructurer() });
            })
            .WriteToDebug()
            .WriteToConsole()
            .WriteToJsonFile();
    }
}
