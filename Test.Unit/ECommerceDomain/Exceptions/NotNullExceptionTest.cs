using ECommerceDomain.Exceptions;

namespace Test.Unit.ECommerceDomain.Exceptions;

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
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<NotNullException>(() =>
        {
            throw new NotNullException(target: "Name")
                .Target(nameof(NotNullExceptionTest));
        });
    }
}
