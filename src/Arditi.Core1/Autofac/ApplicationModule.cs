using System.Reflection;
using Arditi.Application;

namespace Autofac;

public sealed class ApplicationModule : Module
{
    public readonly IList<Assembly> ScanningAssemblies = new List<Assembly>();

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register<MediatR.ServiceFactory>(outerContext =>
        {
            var innerContext = outerContext.Resolve<IComponentContext>();
            return serviceType => innerContext.Resolve(serviceType);
        }).InstancePerDependency();

        builder.Register(context =>
                new RequestSender(new MediatR.Mediator(context.Resolve<MediatR.ServiceFactory>())))
            .As<IRequestSender>().InstancePerDependency();

        builder.Register(context =>
                new MessagePublisher(new MediatR.Mediator(context.Resolve<MediatR.ServiceFactory>())))
            .As<IMessagePublisher>().InstancePerDependency();

        foreach (var pipelineBehavior in new[] { typeof(CommonPipelineBehavior<,>) })
        {
            builder.RegisterGeneric(pipelineBehavior).As(typeof(MediatR.IPipelineBehavior<,>))
                .InstancePerDependency();
        }

        foreach (var handler in new[]
                 {
                     typeof(MediatR.IRequestHandler<,>), typeof(MediatR.INotificationHandler<>),
                     typeof(IRequestMessageFactory<,>)
                 })
        {
            ScanningAssemblies.ForEach(assembly =>
            {
                builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(handler).InstancePerDependency();
            });
        }
    }
}
