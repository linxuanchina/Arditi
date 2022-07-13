using Arditi;
using Arditi.DependencyInjection;
using Arditi.Json;

namespace Autofac;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterJsonSerializerOptionsFactory<T>(
        this ContainerBuilder builder, T instance) where T : class, IJsonSerializerOptionsFactory
    {
        var namedServiceAttribute =
            ExceptionHelper.IsDefinedAttribute<NamedServiceAttribute>(nameof(NamedServiceAttribute), typeof(T));
        builder.RegisterInstance(instance)
            .AsSelf().Named<IJsonSerializerOptionsFactory>(namedServiceAttribute.ServiceName);
        return builder;
    }
}
