using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class NotNullExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new NotNullException("Name")
            .Target(nameof(NotNullExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Contains("Name", result.Message);
        Assert.Equal(nameof(NotNullException), result.Value.Error);
        Assert.Equal(nameof(NotNullExceptionTest), result.Value.Target);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<NotNullException>(() =>
        {
            throw new NotNullException(target: "Name")
                .Target(nameof(NotNullExceptionTest));
        });
    }
}
