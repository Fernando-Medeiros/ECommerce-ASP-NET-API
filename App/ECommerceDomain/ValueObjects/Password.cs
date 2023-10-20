using ECommerceCommon.Exceptions;
using ECommerceCommon.Validations;
using ECommerceDomain.Abstractions;

namespace ECommerceDomain.ValueObjects;

public sealed record Password : ValueObject<string?>
{
    public Password(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? password)
    {
        if (CustomRegexExtension.PasswordHashIsMatch(password) is false)
        {
            throw new PasswordFormatException().Target(nameof(Password));
        }
    }
}