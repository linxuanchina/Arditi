using Arditi.Json;
using Arditi.JuheAPI;
using Arditi.JuheAPI.IDCard;
using Arditi.JuheAPI.IP;
using Arditi.JuheAPI.Mobile;
using Arditi.JuheAPI.Region;
using Refit;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private static readonly Uri s_defaultUri = new UriBuilder("http", "apis.juhe.cn").Uri;

    private static RefitSettings CreateDefaultRefitSettings(IServiceProvider provider) => new()
    {
        ContentSerializer = new SystemTextJsonContentSerializer(provider
            .GetRequiredService<JuheApiJsonSerializerOptionsFactory>().CreateJsonSerializerOptions())
    };

    public static IServiceCollection AddMobileJuheApi(this IServiceCollection services,
        Func<IServiceProvider, JuheApiOptions> configureOptions,
        Action<IServiceProvider, HttpClient>? configureClient = null,
        Action<IServiceProvider, RefitSettings>? configureRefit = null)
    {
        services
            .AddRefitClient<IMobile>(provider =>
            {
                var settings = CreateDefaultRefitSettings(provider);
                configureRefit?.Invoke(provider, settings);
                return settings;
            })
            .ConfigureHttpClient((provider, client) =>
            {
                client.BaseAddress = s_defaultUri;
                configureClient?.Invoke(provider, client);
            })
            .AddHttpMessageHandler(provider => new RequestHandler(configureOptions(provider)));
        return services;
    }

    public static IServiceCollection AddRegionJuheApi(this IServiceCollection services,
        Func<IServiceProvider, JuheApiOptions> configureOptions,
        Action<IServiceProvider, HttpClient>? configureClient = null,
        Action<IServiceProvider, RefitSettings>? configureRefit = null)
    {
        services
            .AddRefitClient<IRegion>(provider =>
            {
                var settings = CreateDefaultRefitSettings(provider);
                configureRefit?.Invoke(provider, settings);
                return settings;
            })
            .ConfigureHttpClient((provider, client) =>
            {
                client.BaseAddress = s_defaultUri;
                configureClient?.Invoke(provider, client);
            })
            .AddHttpMessageHandler(provider => new RequestHandler(configureOptions(provider)));
        return services;
    }

    public static IServiceCollection AddIdCardJuheApi(this IServiceCollection services,
        Func<IServiceProvider, JuheApiOptions> configureOptions,
        Action<IServiceProvider, HttpClient>? configureClient = null,
        Action<IServiceProvider, RefitSettings>? configureRefit = null)
    {
        services
            .AddRefitClient<IIdCard>(provider =>
            {
                var settings = CreateDefaultRefitSettings(provider);
                configureRefit?.Invoke(provider, settings);
                return settings;
            })
            .ConfigureHttpClient((provider, client) =>
            {
                client.BaseAddress = s_defaultUri;
                configureClient?.Invoke(provider, client);
            })
            .AddHttpMessageHandler(provider => new RequestHandler(configureOptions(provider)));
        return services;
    }

    public static IServiceCollection AddIpJuheApi(this IServiceCollection services,
        Func<IServiceProvider, JuheApiOptions> configureOptions,
        Action<IServiceProvider, HttpClient>? configureClient = null,
        Action<IServiceProvider, RefitSettings>? configureRefit = null)
    {
        services
            .AddRefitClient<IIp>(provider =>
            {
                var settings = CreateDefaultRefitSettings(provider);
                configureRefit?.Invoke(provider, settings);
                return settings;
            })
            .ConfigureHttpClient((provider, client) =>
            {
                client.BaseAddress = s_defaultUri;
                configureClient?.Invoke(provider, client);
            })
            .AddHttpMessageHandler(provider => new RequestHandler(configureOptions(provider)));
        return services;
    }
}
