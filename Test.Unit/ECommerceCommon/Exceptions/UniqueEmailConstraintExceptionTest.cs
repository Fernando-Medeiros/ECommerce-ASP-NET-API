using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceCommon.Exceptions;

public class UniqueEmailConstraintExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new UniqueEmailConstraintException()
            .Target(nameof(UniqueEmailConstraintExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(400, result.Value.StatusCode);
        Assert.Equal(nameof(UniqueEmailConstraintException), result.Value.Error);
        Assert.Equal(nameof(UniqueEmailConstraintExceptionTest), result.Value.Target);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<UniqueEmailConstraintException>(() =>
        {
            throw new UniqueEmailConstraintException()
                .Target(nameof(UniqueEmailConstraintExceptionTest));
        });
    }
}
