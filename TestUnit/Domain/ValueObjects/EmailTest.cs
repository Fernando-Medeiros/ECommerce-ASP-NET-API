using ECommerceCommon.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestUnit.Domain.ValueObjects;

public class EmailTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { "t@t.co" };
        yield return new object[] { "test11@m.co" };
        yield return new object[] { "test_11_test@ma.io" };
        yield return new object[] { "1234@mail.com" };
        yield return new object[] { "1234@mail.com.io" };
        yield return new object[] { ".%+-@mail.com" };
        yield return new object[] { "test__.%+-__1234__@mail.com" };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "t@t.c" };
        yield return new object[] { "test@.com" };
        yield return new object[] { "@mail.com" };
        yield return new object[] { "test@mail." };
        yield return new object[] { "!@#$%¨&*()@mail.com" };
        yield return new object[] { "test@@mail.com" };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_Email(string? input)
    {
        Assert.Equal(new Email(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_Email_Or_Not(string? input)
    {
        Assert.Equal(new Email(input, required: false), input);
    }

    [Theory]
    [MemberData(nameof(ExceptionData))]
    public void Should_Throw_Exception_On_Create_Email(string? input)
    {
        Assert.Throws<EmailFormatException>(() => new Email(input));
    }
}
