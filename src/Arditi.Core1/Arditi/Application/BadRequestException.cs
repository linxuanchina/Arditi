namespace Arditi.Application;

public sealed class BadRequestException : ArditiException, IRevealableException
{
    public string Code => "bad_request";
    public string? Description { get; }
    public object? Context { get; }

    public BadRequestException(string message, string? description, object? context) : base(message)
    {
        Context = context;
        Description = description;
    }

    public BadRequestException(string message, string? description, object? context, Exception? innerException) : base(
        message,
        innerException)
    {
        Context = context;
        Description = description;
    }
}
