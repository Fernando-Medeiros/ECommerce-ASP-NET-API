using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class UUIDFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new UUIDFormatException()
            .SetTarget(nameof(UUIDFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(500, result.Value.StatusCode);
        Assert.Equal(nameof(UUIDFormatException), result.Value.Error);
        Assert.Equal(nameof(UUIDFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Return_Exception()
    {
        Assert.ThrowsAny<UUIDFormatException>(() =>
        {
            throw new UUIDFormatException()
                .SetTarget(nameof(UUIDFormatExceptionTest));
        });
    }
}
