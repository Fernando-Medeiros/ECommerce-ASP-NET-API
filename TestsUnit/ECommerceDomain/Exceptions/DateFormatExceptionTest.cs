using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class DateFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new DateFormatException()
            .SetTarget(nameof(DateFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(500, result.Value.StatusCode);
        Assert.Equal(nameof(DateFormatException), result.Value.Error);
        Assert.Equal(nameof(DateFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Return_Exception()
    {
        Assert.ThrowsAny<DateFormatException>(() =>
        {
            throw new DateFormatException()
                .SetTarget(nameof(DateFormatExceptionTest));
        });
    }
}
