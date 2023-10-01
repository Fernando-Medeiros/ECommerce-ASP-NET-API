using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Validations;

public sealed record CustomValidation<T> : Validation<T>
{
    public CustomValidation(
        T? data,
        string target,
        bool required = true) : base(data, target, required) { }
}
