using ECommerceCommon.Exceptions;
using ECommerceCommon.Validations;
using ECommerceDomain.Abstractions;

namespace ECommerceDomain.ValueObjects;

public sealed record Email : ValueObject<string?>
{
    public Email(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? email)
    {
        if (CustomRegexExtension.EmailIsMatch(email) is false)
        {
            throw new EmailFormatException().Target(nameof(Email));
        }
    }
}
