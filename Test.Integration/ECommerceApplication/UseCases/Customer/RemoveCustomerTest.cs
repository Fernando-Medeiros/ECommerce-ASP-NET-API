using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class RemoveCustomerTest : SharedCustomerTest
{
    readonly IUnitTransactionWork _transaction = Substitute.For<IUnitTransactionWork>();

    readonly CustomerDTO CaseInput = new() { Id = Customer.Id };

    [Fact]
    public async void Should_Remove()
    {
        MakeRepositoryStub(
            input: CaseInput,
            output: Customer);

        var useCase = new RemoveCustomer(
            _repository,
            _transaction);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new RemoveCustomer(
            _repository,
            _transaction);

        Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: CaseInput,
                output: null);

            await useCase.Execute(CaseInput);
        });
    }
}
