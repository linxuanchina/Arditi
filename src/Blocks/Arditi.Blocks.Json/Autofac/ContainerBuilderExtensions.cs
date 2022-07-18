using Arditi;
using Arditi.Json;

namespace Autofac;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterJsonSerializerOptionsFactory<T>(
        this ContainerBuilder builder, T instance) where T : class, IJsonSerializerOptionsFactory
    {
        var attribute =
            Check.IsDefinedAttribute<NamedServiceAttribute>(typeof(T));
        builder.RegisterInstance(instance)
            .AsSelf().Named<IJsonSerializerOptionsFactory>(attribute.ServiceName);
        return builder;
    }
}
