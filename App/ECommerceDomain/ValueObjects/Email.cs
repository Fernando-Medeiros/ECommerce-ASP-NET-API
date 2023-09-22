using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;
using ECommerceDomain.Validators;

namespace ECommerceDomain.ValueObjects;

public sealed record Email : ValueObject<string?>
{
    public Email(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? email)
    {
        if (RegexExtensions.EmailIsMatch(email) is false)
        {
            throw new EmailFormatException().Target(nameof(Email));
        }
    }
}
