using Arditi.Security.Claims;

namespace Autofac;

public sealed class WebHostModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpContextCurrentPrincipalAccessor>().As<ICurrentPrincipalAccessor>().SingleInstance();
    }
}
