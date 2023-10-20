using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class UUIDFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new UUIDFormatException()
            .Target(nameof(UUIDFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(500, result.Value.StatusCode);
        Assert.Equal(nameof(UUIDFormatException), result.Value.Error);
        Assert.Equal(nameof(UUIDFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<UUIDFormatException>(() =>
        {
            throw new UUIDFormatException()
                .Target(nameof(UUIDFormatExceptionTest));
        });
    }
}
