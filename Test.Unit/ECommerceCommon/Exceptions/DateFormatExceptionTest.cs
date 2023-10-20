using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class DateFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new DateFormatException()
            .Target(nameof(DateFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(500, result.Value.StatusCode);
        Assert.Equal(nameof(DateFormatException), result.Value.Error);
        Assert.Equal(nameof(DateFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<DateFormatException>(() =>
        {
            throw new DateFormatException()
                .Target(nameof(DateFormatExceptionTest));
        });
    }
}
