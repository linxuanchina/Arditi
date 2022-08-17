namespace Arditi.Application;

public sealed class InvalidRequestException : ArditiException, IRevealableException
{
    public string Code => "invalid_request";
    public string? Description { get; }
    public object? Context { get; }

    public InvalidRequestException(string message, string? description, object? context) : base(message)
    {
        Context = context;
        Description = description;
    }

    public InvalidRequestException(string message, string? description, object? context, Exception? innerException) :
        base(message,
            innerException)
    {
        Context = context;
        Description = description;
    }
}
