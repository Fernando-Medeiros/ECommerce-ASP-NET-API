using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

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
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<PasswordFormatException>(() =>
        {
            throw new PasswordFormatException()
                .Target(nameof(PasswordFormatExceptionTest));
        });
    }
}
