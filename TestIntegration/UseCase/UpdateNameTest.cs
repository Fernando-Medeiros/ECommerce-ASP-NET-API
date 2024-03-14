using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceDomain.DTO;
using NSubstitute;
using ECommerceApplication.Contract;
using ECommerceTestSetup.Shared;

namespace TestIntegration.UseCase;

public sealed class UpdateNameTest : SharedCustomerTest
{
    readonly ITransaction _transaction;
    readonly IdentityRequest Identity;
    readonly NameRequest Payload;
    readonly CustomerDTO Query;

    public UpdateNameTest()
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

        var useCase = new UpdateName(_transaction, _repository);

        await useCase.Execute((Identity, Payload));
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new UpdateName(_transaction, _repository);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(input: Query, output: null);

            await useCase.Execute((Identity, Payload));
        });
    }
}
