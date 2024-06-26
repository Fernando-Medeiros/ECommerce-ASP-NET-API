using ECommerceCommon.Exceptions;

namespace TestUnit.Common.Exceptions;

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
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<NameFormatException>(() =>
        {
            throw new NameFormatException()
                .Target(nameof(NameFormatExceptionTest));
        });
    }
}
