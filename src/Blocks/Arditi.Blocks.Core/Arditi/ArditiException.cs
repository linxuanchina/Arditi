using System.Runtime.Serialization;

namespace Arditi;

public class ArditiException : Exception
{
    public ArditiException()
    {
    }

    public ArditiException(string? message) : base(message)
    {
    }

    public ArditiException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ArditiException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {
    }
}
