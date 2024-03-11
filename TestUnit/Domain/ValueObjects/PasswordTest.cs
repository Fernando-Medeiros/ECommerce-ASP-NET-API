using ECommerceCommon.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestUnit.Domain.ValueObjects;

public class PasswordTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { BCrypt.Net.BCrypt.HashPassword("test123") };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "anyPassword123" };
        yield return new object[] { "notHashPassword" };
        yield return new object[] { "0123456789" };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_Password(string? input)
    {
        Assert.Equal(new Password(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_Password_Or_Not(string? input)
    {
        Assert.Equal(new Password(input, required: false), input);
    }

    [Theory]
    [MemberData(nameof(ExceptionData))]
    public void Should_Throw_Exception_On_Create_Password(string? input)
    {
        Assert.Throws<PasswordFormatException>(() => new Password(input));
    }
}
