using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record Email : ValueObject<string?>
{
    public Email(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? email)
    {
        if (Regex.IsMatch(email ?? "", RegexTypes.Email) is false)
        {
            throw new EmailFormatException().Target(nameof(Email));
        }
    }
}
