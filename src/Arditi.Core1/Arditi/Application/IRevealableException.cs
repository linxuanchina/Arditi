namespace Arditi.Application;

public interface IRevealableException
{
    string Code { get; }
    string? Description { get; }
    object? Context { get; }
}
