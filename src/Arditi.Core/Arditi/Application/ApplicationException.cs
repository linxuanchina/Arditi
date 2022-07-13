namespace Arditi.Application;

public abstract class ApplicationException : ArditiException
{
    public abstract int Code { get; }
    public object? Context { get; }

    protected ApplicationException(string message, object? context) : base(message)
    {
        Context = context;
    }

    protected ApplicationException(string message, object? context, Exception? innerException) : base(message,
        innerException)
    {
        Context = context;
    }
}

public sealed class BadRequestException : ApplicationException
{
    public override int Code => 99;

    public BadRequestException(string message, object? context) : base(message, context)
    {
    }

    public BadRequestException(string message, object? context, Exception? innerException) : base(message, context,
        innerException)
    {
    }
}

public sealed class InvalidRequestException : ApplicationException
{
    public override int Code => 1;

    public InvalidRequestException(string message, object? context) : base(message, context)
    {
    }

    public InvalidRequestException(string message, object? context, Exception? innerException) : base(message, context,
        innerException)
    {
    }
}
