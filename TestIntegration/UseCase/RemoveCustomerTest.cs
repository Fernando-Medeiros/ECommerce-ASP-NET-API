using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using NSubstitute;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Shared;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase.CustomerCases;

namespace TestIntegration.UseCase;

public sealed class RemoveCustomerTest : SharedCustomerTest
{
    readonly ITransaction _transaction;
    readonly IdentityRequest Identity;
    readonly CustomerDTO Query;

    public RemoveCustomerTest()
    {
        _transaction = Substitute.For<ITransaction>();
        Query = new() { Id = Mock.UniqueId };
        Identity = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Remove()
    {
        MakeRepositoryStub(input: Query, output: Mock.CustomerDTO);

        var useCase = new RemoveCustomer(_transaction, _repository);

        await useCase.Execute(Identity);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new RemoveCustomer(_transaction, _repository);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(input: Query, output: null);

            await useCase.Execute(Identity);
        });
    }
}
