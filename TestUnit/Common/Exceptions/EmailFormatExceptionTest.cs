using ECommerceCommon.Exceptions;

namespace TestUnit.Common.Exceptions;

public class EmailFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new EmailFormatException()
            .Target(nameof(EmailFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(EmailFormatException), result.Value.Error);
        Assert.Equal(nameof(EmailFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<EmailFormatException>(() =>
        {
            throw new EmailFormatException()
                .Target(nameof(EmailFormatExceptionTest));
        });
    }
}
