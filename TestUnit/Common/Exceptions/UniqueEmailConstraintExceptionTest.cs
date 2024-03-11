using ECommerceCommon.Exceptions;

namespace TestUnit.Common.Exceptions;

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
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<UniqueEmailConstraintException>(() =>
        {
            throw new UniqueEmailConstraintException()
                .Target(nameof(UniqueEmailConstraintExceptionTest));
        });
    }
}
