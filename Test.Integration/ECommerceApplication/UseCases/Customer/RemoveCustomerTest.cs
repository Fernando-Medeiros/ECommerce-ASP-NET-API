using ECommerceApplication.Contracts;
using ECommerceCommon.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class RemoveCustomerTest : SharedCustomerTest
{
    readonly IUnitTransactionWork _transaction;

    readonly CustomerDTO CaseInput;

    public RemoveCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransactionWork>();

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
