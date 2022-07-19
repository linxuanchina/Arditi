using Serilog;
using Serilog.Configuration;
using Serilog.Exceptions.Destructurers;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Exceptions.Refit.Destructurers;

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
            .EnrichWithExceptionDetails(options =>
            {
                options
                    .WithDefaultDestructurers()
                    .WithDestructurers(new ExceptionDestructurer[]
                    {
                        new ApiExceptionDestructurer(), new DbUpdateExceptionDestructurer()
                    });
            })
            .WriteToConsole();

        if (_context.HostingEnvironment.IsDevelopment())
        {
            configuration.WriteToDebug();
        }
        else
        {
            configuration.WriteToJsonFile();
        }
    }
}
