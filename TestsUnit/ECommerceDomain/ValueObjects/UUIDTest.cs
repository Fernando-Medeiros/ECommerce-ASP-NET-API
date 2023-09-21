using ECommerceDomain.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestsUnit.ECommerceDomain.ValueObjects;

public class UUIDTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { Guid.NewGuid().ToString() };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "012345-12345-12345-12345-12345-12345" };
        yield return new object[] { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };
        yield return new object[] { Guid.NewGuid().ToString() + "123" };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_UUID(string? input)
    {
        Assert.Equal(new UUID(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_UUID_Or_Not(string? input)
    {
        Assert.Equal(new UUID(input, required: false), input);
    }

    [Theory]
    [MemberData(nameof(ExceptionData))]
    public void Should_Throw_Exception_On_Create_UUID(string? input)
    {
        Assert.Throws<UUIDFormatException>(() => new UUID(input));
    }
}
