using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class FullNameFormatExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new NameFormatException()
            .Target(nameof(FullNameFormatExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(NameFormatException), result.Value.Error);
        Assert.Equal(nameof(FullNameFormatExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<NameFormatException>(() =>
        {
            throw new NameFormatException()
                .Target(nameof(FullNameFormatExceptionTest));
        });
    }
}
