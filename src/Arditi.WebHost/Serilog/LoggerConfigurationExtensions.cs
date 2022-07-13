using System.Text;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.SystemConsole.Themes;

namespace Serilog;

public static class LoggerConfigurationExtensions
{
    public static LoggerConfiguration OverrideMicrosoftAspNetCoreToWarning(this LoggerConfiguration configuration) =>
        configuration
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning);

    public static LoggerConfiguration WriteToDebug(this LoggerConfiguration configuration) =>
        configuration.WriteTo.Debug(
            restrictedToMinimumLevel: LogEventLevel.Debug
        );


    public static LoggerConfiguration WriteToConsole(this LoggerConfiguration configuration) =>
        configuration.WriteTo.Console(
            restrictedToMinimumLevel: LogEventLevel.Debug,
            theme: SystemConsoleTheme.Colored
        );


    public static LoggerConfiguration WriteToJsonFile(this LoggerConfiguration configuration) =>
        configuration.WriteTo.File(
            restrictedToMinimumLevel: LogEventLevel.Information,
            encoding: Encoding.UTF8,
            rollingInterval: RollingInterval.Day,
            retainedFileTimeLimit: TimeSpan.FromDays(10),
            shared: true,
            path: "logs/.json",
            formatter: new JsonFormatter(renderMessage: true)
        );
}
