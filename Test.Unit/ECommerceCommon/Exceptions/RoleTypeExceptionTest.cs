using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class RoleTypeExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new RoleTypeException()
            .Target(nameof(RoleTypeExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(RoleTypeException), result.Value.Error);
        Assert.Equal(nameof(RoleTypeExceptionTest), result.Value.Target);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<RoleTypeException>(() =>
        {
            throw new RoleTypeException()
                .Target(nameof(RoleTypeExceptionTest));
        });
    }
}
