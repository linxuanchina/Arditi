namespace Arditi.Application;

public abstract class ResponsiveException : ArditiException
{
    public abstract int Code { get; }
    public object? Context { get; }

    protected ResponsiveException(string message, object? context) : base(message)
    {
        Context = context;
    }

    protected ResponsiveException(string message, object? context, Exception? innerException) : base(message,
        innerException)
    {
        Context = context;
    }
}

public sealed class BadRequestException : ResponsiveException
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

public sealed class InvalidRequestException : ResponsiveException
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
