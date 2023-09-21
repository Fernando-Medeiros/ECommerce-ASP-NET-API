using ECommerceDomain.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestsUnit.ECommerceDomain.ValueObjects;

public class DateTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { DateTimeOffset.Now };
        yield return new object[] { DateTimeOffset.UtcNow };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_Date(DateTimeOffset? input)
    {
        Assert.Equal(new Date(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_Date_Or_Not(DateTimeOffset? input)
    {
        Assert.Equal(new Date(input, required: false), input);
    }

    [Theory]
    [InlineData(null)]
    public void Should_Throw_Exception_On_Create_Date(DateTimeOffset? input)
    {
        Assert.Throws<DateFormatException>(() => new Date(input));
    }
}
