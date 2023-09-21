namespace ECommerceDomain.Abstractions;

public abstract record Validator<T>
{
    public string Target { get; private init; }

    public bool Required { get; private init; }

    public T? Value { get; private init; }

    public Validator(T? data, string target, bool required = true)
    {
        Required = required;
        Target = target;
        Value = data;
    }

    public static implicit operator T?(Validator<T?> obj) { return obj.Value; }

    public bool IsRequired() => Required || Value != null;
}
