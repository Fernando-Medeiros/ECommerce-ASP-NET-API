using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceDomain.Exceptions;

public class RoleTypeExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new RoleTypeException()
            .Target(nameof(RoleTypeExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(404, result.Value.StatusCode);
        Assert.Equal(nameof(RoleTypeException), result.Value.Error);
        Assert.Equal(nameof(RoleTypeExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Return_Exception()
    {
        Assert.ThrowsAny<RoleTypeException>(() =>
        {
            throw new RoleTypeException()
                .Target(nameof(RoleTypeExceptionTest));
        });
    }
}
