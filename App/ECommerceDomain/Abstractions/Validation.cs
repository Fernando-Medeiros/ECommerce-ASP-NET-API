namespace ECommerceDomain.Abstractions;

public abstract record Validation<T>
{
    public string Target { get; private init; }
    public bool Required { get; private init; }
    public T? Value { get; private init; }

    public Validation(T? data, string target, bool required = true)
    {
        Required = required;
        Target = target;
        Value = data;
    }

    public bool IsRequired() => Required || Value is T;

    public static implicit operator T?(Validation<T?> obj) { return obj.Value; }
}
