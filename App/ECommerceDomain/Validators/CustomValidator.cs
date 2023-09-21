using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Validators;

public sealed record CustomValidator<T> : Validator<T>
{
    public CustomValidator(
        T? data,
        string target,
        bool required = true) : base(data, target, required) { }
}
