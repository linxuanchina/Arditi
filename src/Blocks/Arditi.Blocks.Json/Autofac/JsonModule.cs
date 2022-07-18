using Arditi.Json;

namespace Autofac;

public sealed class JsonModule : Module
{
    public readonly IList<IJsonSerializerOptionsFactory> JsonSerializerOptionsFactories =
        new List<IJsonSerializerOptionsFactory>();

    protected override void Load(ContainerBuilder builder)
    {
        foreach (var factory in JsonSerializerOptionsFactories)
        {
            builder.RegisterJsonSerializerOptionsFactory(factory);
        }
    }
}
