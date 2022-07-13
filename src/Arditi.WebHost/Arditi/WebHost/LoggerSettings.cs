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
            .WriteToConsole();

        if (_context.HostingEnvironment.IsDevelopment())
        {
            configuration.WriteToDebug();
        }

        if (_context.HostingEnvironment.IsStaging() || _context.HostingEnvironment.IsProduction())
        {
            configuration.WriteToJsonFile();
        }
    }
}
