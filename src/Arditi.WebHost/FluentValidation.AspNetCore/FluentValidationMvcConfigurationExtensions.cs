using Arditi.Application;

namespace FluentValidation.AspNetCore;

public static class FluentValidationMvcConfigurationExtensions
{
    public static FluentValidationMvcConfiguration ConfigureFluentValidationMvc(
        this FluentValidationMvcConfiguration configuration)
    {
        configuration.AutomaticValidationEnabled = true;
        configuration.DisableDataAnnotationsValidation = true;
        configuration.RegisterValidatorsFromAssemblies(new[] { typeof(IApplicationLocator).Assembly });
        return configuration;
    }
}
