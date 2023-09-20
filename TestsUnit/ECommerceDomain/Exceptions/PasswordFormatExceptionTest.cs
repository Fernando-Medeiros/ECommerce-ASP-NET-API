using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class PasswordFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new PasswordFormatException()
            .Target(nameof(PasswordFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(404, result.Value.StatusCode);
        Assert.Equal(nameof(PasswordFormatException), result.Value.Error);
        Assert.Equal(nameof(PasswordFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Return_Exception()
    {
        Assert.ThrowsAny<PasswordFormatException>(() =>
        {
            throw new PasswordFormatException()
                .Target(nameof(PasswordFormatExceptionTest));
        });
    }
}
