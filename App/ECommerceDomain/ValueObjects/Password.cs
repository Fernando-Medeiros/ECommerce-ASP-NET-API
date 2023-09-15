using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class Password : ValueObject<string?>
{
    public override ValueObject<string?> Validate(string? password)
    {
        if (Required &&
            Regex.IsMatch(password ?? "", RegexTypes.PasswordHash) is false)
        {
            throw new PasswordFormatException().SetTarget(nameof(Password));
        }
        return this;
    }
}