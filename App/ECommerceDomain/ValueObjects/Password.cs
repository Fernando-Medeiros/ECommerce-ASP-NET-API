using System.Text.RegularExpressions;
using ECommerceDomain.Abstractions;
using ECommerceDomain.Constants;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record Password : ValueObject<string?>
{
    public Password(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? password)
    {
        if (Regex.IsMatch(password ?? "", RegexTypes.PasswordHash) is false)
        {
            throw new PasswordFormatException().Target(nameof(Password));
        }
    }
}