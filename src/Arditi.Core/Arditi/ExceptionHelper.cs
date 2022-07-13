using System.ComponentModel;

namespace Arditi;

public static class ExceptionHelper
{
    public static InvalidEnumArgumentException InvalidEnumArgument<T>(string? paramName, T value)
        where T : struct, Enum =>
        new(paramName, value.To<int>(), typeof(T));

    public static T IsDefinedAttribute<T>(string attrName, Type type, bool inherit = true) where T : Attribute
    {
        var attribute = Attribute.GetCustomAttribute(type, typeof(T), inherit);
        return NotNull(attribute, attrName).To<T>();
    }

    public static T NotNull<T>(T value, string paramName)
    {
        if (value == null)
        {
            throw new ArgumentNullException(paramName);
        }

        return value;
    }

    public static T NotDefault<T>(T value, string paramName) where T : struct
    {
        if (value.IsDefault())
        {
            throw new ArgumentException($"{paramName} has a default value", paramName);
        }

        return value;
    }

    public static ICollection<T> NotEmpty<T>(ICollection<T> value, string paramName)
    {
        if (value.IsEmpty())
        {
            throw new ArgumentException(paramName + " can not be empty", paramName);
        }

        return value;
    }

    public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, string paramName)
    {
        if (value.IsNullOrEmpty())
        {
            throw new ArgumentException(paramName + " can not be null or empty", paramName);
        }

        return value;
    }

    public static Guid NotEmpty(Guid value, string paramName)
    {
        if (value.IsEmpty())
        {
            throw new ArgumentException($"{paramName} can not be empty", paramName);
        }

        return value;
    }

    public static string NotEmpty(string value, string paramName)
    {
        if (value.IsEmpty())
        {
            throw new ArgumentException($"{paramName} can not be empty", paramName);
        }

        return value;
    }

    public static string NotNullOrEmpty(string value, string paramName)
    {
        if (value.IsNullOrEmpty())
        {
            throw new ArgumentException($"{paramName} can not be null or empty", paramName);
        }

        return value;
    }

    public static string Length(string value, string paramName, int maxLength, int minLength = 0)
    {
        NotEmpty(value, paramName);
        if (value.Length < minLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}", paramName);
        }

        if (value.Length > maxLength)
        {
            throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}", paramName);
        }

        return value;
    }

    public static int Range(int value, string paramName, int minimum, int maximum = int.MaxValue)
    {
        if (value >= minimum && value <= maximum)
        {
            return value;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static long Range(long value, string paramName, long minimum, long maximum = long.MaxValue)
    {
        if (value >= minimum && value <= maximum)
        {
            return value;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static decimal Range(decimal value, string paramName, decimal minimum, decimal maximum = decimal.MaxValue)
    {
        if (value >= minimum && value <= maximum)
        {
            return value;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static float Range(float value, string paramName, float minimum, float maximum = float.MaxValue)
    {
        if (value >= minimum && value <= maximum)
        {
            return value;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }

    public static double Range(double value, string paramName, double minimum, double maximum = double.MaxValue)
    {
        if (value >= minimum && value <= maximum)
        {
            return value;
        }

        throw new ArgumentException($"{paramName} is out of range min: {minimum} - max: {maximum}", paramName);
    }
}
