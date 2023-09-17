using ECommerceDomain.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestsUnit.ECommerceDomain.ValueObjects;

public class NameTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { "Test" };
        yield return new object[] { "John" };
        yield return new object[] { "Shu Yang" };
        yield return new object[] { "John Dee" };
        yield return new object[] { "Julius Cesar" };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "Test0022" };
        yield return new object[] { "2023" };
        yield return new object[] { "Example 00" };
        yield return new object[] { "john ddd" };
        yield return new object[] { "john dee dee" };
        yield return new object[] { "_Example_" };
        yield return new object[] { "!@#$%¨&*()@." };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_Name(string? input)
    {
        Assert.Equal(new Name(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_Name_Or_Not(string? input)
    {
        Assert.Equal(new Name(input, required: false), input);
    }

    [Theory]
    [MemberData(nameof(ExceptionData))]
    public void Should_Return_Exception_On_Create_Name(string? input)
    {
        Assert.Throws<NameFormatException>(() => new Name(input));
    }
}
