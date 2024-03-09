using System.Text.RegularExpressions;
using ECommerceCommon.Constant;

namespace ECommerceCommon.Validations;

public static partial class CustomRegexExtension
{
    [GeneratedRegex(RegexType.Name)]
    private static partial Regex Name();

    [GeneratedRegex(RegexType.Email)]
    private static partial Regex Email();

    [GeneratedRegex(RegexType.Password)]
    private static partial Regex Password();

    [GeneratedRegex(RegexType.PasswordHash)]
    private static partial Regex PasswordHash();

    public static bool NameIsMatch<T>(T? value) =>
        CustomRegexExtension.Name().IsMatch($"{value}");

    public static bool EmailIsMatch<T>(T? value) =>
        CustomRegexExtension.Email().IsMatch($"{value}");

    public static bool PasswordIsMatch<T>(T? value) =>
        CustomRegexExtension.Password().IsMatch($"{value}");

    public static bool PasswordHashIsMatch<T>(T? value) =>
        CustomRegexExtension.PasswordHash().IsMatch($"{value}");
}
