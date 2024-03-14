using ECommerceCommon.Exceptions;
using ECommerceApplication.UseCase;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Shared;
using ECommerceApplication.Request;

namespace TestIntegration.UseCase;

public sealed class FindCustomerTest : SharedCustomerTest
{
    readonly IdentityRequest Identity;
    readonly CustomerDTO Query;

    public FindCustomerTest()
    {
        Query = new() { Id = Mock.UniqueId };
        Identity = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Return_One_Customer()
    {
        MakeRepositoryStub(input: Query, output: Mock.CustomerDTO);

        var useCase = new FindCustomer(_repository);

        var result = await useCase.Execute(Identity);

        Assert.Equivalent(Mock.CustomerDTO, result);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new FindCustomer(_repository);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(input: Query, output: null);

            _ = await useCase.Execute(Identity);
        });
    }
}
