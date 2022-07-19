using System.ComponentModel;

namespace Arditi;

public static class ExceptionHelper
{
    public static InvalidEnumArgumentException InvalidEnumArgument<T>(string? paramName, T value)
        where T : struct, Enum =>
        new(paramName, value.To<int>(), typeof(T));
}
