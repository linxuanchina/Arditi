namespace Arditi.DependencyInjection;

[AttributeUsage(AttributeTargets.Class)]
public sealed class NamedServiceAttribute : Attribute
{
    public NamedServiceAttribute(string serviceName)
    {
        ServiceName = ExceptionHelper.NotEmpty(serviceName, nameof(serviceName));
    }

    public string ServiceName { get; }

    public override bool Equals(object? obj) =>
        obj is NamedServiceAttribute other && StringHelper.Compare(other.ServiceName, ServiceName);

    public override int GetHashCode() => ServiceName.GetHashCode();
}
