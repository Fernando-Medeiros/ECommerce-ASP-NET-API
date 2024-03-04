using ECommerceCommon.Exceptions;

namespace ECommerceTest.Unit.ECommerceCommon.Exceptions;

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
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<NameFormatException>(() =>
        {
            throw new NameFormatException()
                .Target(nameof(FullNameFormatExceptionTest));
        });
    }
}
