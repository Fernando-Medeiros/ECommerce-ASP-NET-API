using ECommerceCommon.Exceptions;

namespace ECommerceTest.Unit.ECommerceCommon.Exceptions;

public class CustomerNotFoundExceptionTest
{
    [Fact]
    public void Should_Create_Exception()
    {
        var result = new CustomerNotFoundException()
            .Target(nameof(CustomerNotFoundExceptionTest));

        Assert.NotNull(result.Value.Message);
        Assert.Equal(404, result.Value.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), result.Value.Error);
        Assert.Equal(nameof(CustomerNotFoundExceptionTest), result.Value.Target);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(() =>
        {
            throw new CustomerNotFoundException()
                .Target(nameof(CustomerNotFoundExceptionTest));
        });
    }
}
