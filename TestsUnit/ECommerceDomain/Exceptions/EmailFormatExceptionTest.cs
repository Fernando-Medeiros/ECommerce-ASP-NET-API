using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class EmailFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new EmailFormatException()
            .Target(nameof(EmailFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(404, result.Value.StatusCode);
        Assert.Equal(nameof(EmailFormatException), result.Value.Error);
        Assert.Equal(nameof(EmailFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Return_Exception()
    {
        Assert.ThrowsAny<EmailFormatException>(() =>
        {
            throw new EmailFormatException()
                .Target(nameof(EmailFormatExceptionTest));
        });
    }
}
