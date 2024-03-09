namespace ECommerceCommon.Validations;

public sealed record CustomValidation<T>(
    T? Value,
    string Target,
    bool Required = true
)
{
    public bool IsRequired() => Required || Value is T;

    public static implicit operator T?(CustomValidation<T?> obj) { return obj.Value; }
}