using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using NSubstitute;
using ECommerceApplication.Contract;
using ECommerceTestSetup.Shared;
using ECommerceApplication.UseCase.CustomerCases;

namespace TestIntegration.UseCase;

public sealed class UpdateCustomerNameTest : SharedCustomerTest
{
    readonly ITransaction _transaction;
    readonly IdentityRequest Identity;
    readonly NameRequest Payload;
    readonly CustomerDTO Query;

    public UpdateCustomerNameTest()
    {
        _transaction = Substitute.For<ITransaction>();
        Payload = Mock.UpdateRequest;
        Query = new() { Id = Mock.UniqueId };
        Identity = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Update_Customer_NameOrEmail()
    {
        MakeRepositoryStub(input: Query, output: Mock.CustomerDTO);

        var useCase = new UpdateCustomerName(_transaction, _repository);

        await useCase.Execute((Identity, Payload));
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new UpdateCustomerName(_transaction, _repository);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(input: Query, output: null);

            await useCase.Execute((Identity, Payload));
        });
    }
}
