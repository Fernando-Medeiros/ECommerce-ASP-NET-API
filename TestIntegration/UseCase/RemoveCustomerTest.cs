using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using ECommerceApplication.UseCase;
using NSubstitute;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Shared;

namespace TestIntegration.UseCase;

public sealed class RemoveCustomerTest : SharedCustomerTest
{
    readonly IUnitTransaction _transaction;

    readonly CustomerDTO CaseInput;

    public RemoveCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransaction>();

        CaseInput = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Remove()
    {
        MakeRepositoryStub(
            input: CaseInput,
            output: Mock.CustomerDTO);

        var useCase = new RemoveCustomer(
            _repository,
            _transaction);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new RemoveCustomer(
            _repository,
            _transaction);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: CaseInput,
                output: null);

            await useCase.Execute(CaseInput);
        });
    }
}
