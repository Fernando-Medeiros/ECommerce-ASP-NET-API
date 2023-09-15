using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class Email : ValueObject<string?>
{
    public override ValueObject<string?> Validate(string? email)
    {
        if (Required && Regex.IsMatch(email ?? "", RegexTypes.Email) is false)
        {
            throw new EmailFormatException().SetTarget(nameof(Email));
        }
        return this;
    }
}
