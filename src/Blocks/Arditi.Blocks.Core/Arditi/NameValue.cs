namespace Arditi;

public sealed record NameValue<TValue> where TValue : notnull
{
    public NameValue(string name, TValue value)
    {
        Name = Check.NotEmpty(name, nameof(name));
        Value = value;
    }

    public string Name { get; }

    public TValue Value { get; }
}
