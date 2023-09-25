using ECommerceDomain.Exceptions;

namespace Test.Unit.ECommerceDomain.Exceptions;

public class NameFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new NameFormatException()
            .Target(nameof(NameFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(NameFormatException), result.Value.Error);
        Assert.Equal(nameof(NameFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<NameFormatException>(() =>
        {
            throw new NameFormatException()
                .Target(nameof(NameFormatExceptionTest));
        });
    }
}
