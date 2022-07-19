using System.Text.Json;
using System.Text.Json.Serialization;
using Arditi.Application;
using Arditi.WebHost;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

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
        var applicationModule = new ApplicationModule();
        applicationModule.ScanningAssemblies.Add(typeof(IApplicationLocator).Assembly);
        builder.RegisterModule(applicationModule);
        var webHostModule = new WebHostModule();
        builder.RegisterModule(webHostModule);
    }));
    webAppBuilder.WebHost.ConfigureServices(services =>
    {
        services.AddHttpContextAccessor();
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.IgnoreReadOnlyFields = false;
                options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
                options.JsonSerializerOptions.IncludeFields = false;
                options.JsonSerializerOptions.MaxDepth = 64;
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Disallow;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions
                    .AddGuidConverter()
                    .AddLongEpochTimeConverter()
                    .AddResponsiveExceptionConverter();
            })
            .AddFluentValidation(configuration =>
            {
                configuration.AutomaticValidationEnabled = true;
                configuration.DisableDataAnnotationsValidation = true;
                configuration.RegisterValidatorsFromAssemblyContaining<IApplicationLocator>();
            });

        if (webAppBuilder.Environment.IsDevelopment())
        {
            services.AddSwaggerGen(genOptions =>
            {
                genOptions.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "标题",
                        Version = "2022.7.19",
                        Contact = new OpenApiContact { Name = "Dokey", Email = "linxuanchina@gmail.com" }
                    });
                genOptions.UseAllOfToExtendReferenceSchemas();
                genOptions.AddEnumsWithValuesFixFilters(null, enumsOptions =>
                {
                    enumsOptions.ApplySchemaFilter = true;
                    enumsOptions.ApplyParameterFilter = true;
                    enumsOptions.ApplyDocumentFilter = true;
                    enumsOptions.IncludeXEnumRemarks = true;
                    enumsOptions.IncludeDescriptions = true;
                    enumsOptions.DescriptionSource = DescriptionSources.DescriptionAttributes;
                });
            });
            services.AddFluentValidationRulesToSwagger();
        }
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
    if (webApp.Environment.IsDevelopment())
    {
        webApp.UseSwagger();
        webApp.UseSwaggerUI(options =>
        {
        });
    }

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
