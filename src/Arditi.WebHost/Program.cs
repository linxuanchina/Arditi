using Arditi.WebHost;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteToConsole()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up");

    var webAppBuilder = WebApplication.CreateBuilder(args);

    webAppBuilder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration.ReadFrom.Settings(new LoggerSettings(context));
        configuration.ReadFrom.Services(services);
    });

    webAppBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
            {
                builder.RegisterApplication();
            }
        )
    );

    webAppBuilder.WebHost.ConfigureServices(services =>
    {
        services.AddHttpContextAccessor();
        services
            .AddControllers()
            .AddJsonOptions(options => options.ConfigureJsonSerializer())
            .AddFluentValidation(configuration => configuration.ConfigureFluentValidationMvc());
    });

    var webApp = webAppBuilder.Build();

    webApp.UseSerilogRequestLogging();
    webApp.UseRouting();
    webApp.UseAuthentication();
    webApp.UseAuthorization();
    webApp.UseEndpoints(route =>
    {
        route.MapControllers();
    });

    await webApp.RunAsync();

    Log.Information("Stopped cleanly");

    return 0;
}
catch (Exception exception)
{
    Log.Fatal(exception, "An unhandled exception occured during bootstrapping");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
