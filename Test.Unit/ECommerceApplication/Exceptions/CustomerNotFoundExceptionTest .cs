using ECommerceApplication.Exceptions;

namespace Test.Unit.ECommerceDomain.Exceptions;

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
    public void Should_Throw_Exception()
    {
        Assert.ThrowsAny<CustomerNotFoundException>(() =>
        {
            throw new CustomerNotFoundException()
                .Target(nameof(CustomerNotFoundExceptionTest));
        });
    }
}
