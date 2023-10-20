using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class NotEmptyExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new NotEmptyException("Name")
            .Target(nameof(NotEmptyExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Contains("Name", result.Message);
        Assert.Equal(nameof(NotEmptyException), result.Value.Error);
        Assert.Equal(nameof(NotEmptyExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<NotEmptyException>(() =>
        {
            throw new NotEmptyException(target: "Name")
                .Target(nameof(NotEmptyExceptionTest));
        });
    }
}
