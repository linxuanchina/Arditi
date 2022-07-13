using Arditi.Application;

namespace Autofac;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterApplication(this ContainerBuilder builder)
    {
        var module = new ApplicationModule();
        module.ScanningAssemblies.Add(typeof(IApplicationLocator).Assembly);
        builder.RegisterModule(module);
        return builder;
    }
}
