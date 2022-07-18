using Arditi;

namespace Autofac;

public static class ContainerExtensions
{
    public static TService ResolveNamedService<TService>(this IContainer container, Type namedServiceType)
        where TService : notnull =>
        container.ResolveNamed<TService>(Check
            .IsDefinedAttribute<NamedServiceAttribute>(namedServiceType).ServiceName);

    public static TService ResolveNamedService<TService, TImplementation>(this IContainer container)
        where TService : notnull
        where TImplementation : notnull =>
        ResolveNamedService<TService>(container, typeof(TImplementation));
}
