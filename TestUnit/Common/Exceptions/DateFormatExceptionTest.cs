using ECommerceCommon.Exceptions;

namespace TestUnit.Common.Exceptions;

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
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<DateFormatException>(() =>
        {
            throw new DateFormatException()
                .Target(nameof(DateFormatExceptionTest));
        });
    }
}
