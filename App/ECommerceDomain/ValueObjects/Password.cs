using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;
using ECommerceDomain.Validators;

namespace ECommerceDomain.ValueObjects;

public sealed record Password : ValueObject<string?>
{
    public Password(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? password)
    {
        if (RegexExtensions.PasswordHashIsMatch(password) is false)
        {
            throw new PasswordFormatException().Target(nameof(Password));
        }
    }
}