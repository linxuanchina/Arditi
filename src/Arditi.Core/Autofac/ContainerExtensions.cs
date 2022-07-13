using Arditi;
using Arditi.DependencyInjection;

namespace Autofac;

public static class ContainerExtensions
{
    public static TService ResolveNamedService<TService>(this IContainer container, Type namedServiceType)
        where TService : notnull =>
        container.ResolveNamed<TService>(ExceptionHelper
            .IsDefinedAttribute<NamedServiceAttribute>(nameof(NamedServiceAttribute), namedServiceType).ServiceName);

    public static TService ResolveNamedService<TService, TImplementationService>(this IContainer container)
        where TService : notnull
        where TImplementationService : notnull =>
        ResolveNamedService<TService>(container, typeof(TImplementationService));
}
