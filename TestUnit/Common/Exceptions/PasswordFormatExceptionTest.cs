using ECommerceCommon.Exceptions;

namespace TestUnit.Common.Exceptions;

public class PasswordFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new PasswordFormatException()
            .Target(nameof(PasswordFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(PasswordFormatException), result.Value.Error);
        Assert.Equal(nameof(PasswordFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<PasswordFormatException>(() =>
        {
            throw new PasswordFormatException()
                .Target(nameof(PasswordFormatExceptionTest));
        });
    }
}
