using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class LengthExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new LengthException(target: "Name", min: 3, max: 20)
            .Target(nameof(LengthExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Contains("Name", result.Message);
        Assert.Equal(nameof(LengthException), result.Value.Error);
        Assert.Equal(nameof(LengthExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<LengthException>(() =>
        {
            throw new LengthException(target: "Name", min: 3, max: 20)
                .Target(nameof(LengthExceptionTest));
        });
    }
}
