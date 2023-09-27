using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.Abstractions;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class UpdateCustomerNameAndEmailTest : SharedCustomerTest
{
    readonly IUnitTransactionWork _transaction = Substitute.For<IUnitTransactionWork>();

    readonly UpdateCustomerRequest CaseInput = UpdateRequest;

    [Fact]
    public async void Should_Update_Customer_NameOrEmail()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = CaseInput.Id },
            output: Customer);
        MakeRepositoryStub(
            input: new CustomerDTO() { Email = CaseInput.Email },
            output: null);

        var useCase = new UpdateCustomerNameAndEmail(
            _repository,
            _transaction);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new UpdateCustomerNameAndEmail(
            _repository,
            _transaction);

        Assert.ThrowsAsync<DomainException>(async () =>
        {
            var invalidCaseInput = CaseInput with { Email = "$$$@mail.com" };

            await useCase.Execute(invalidCaseInput);
        });

        Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: new CustomerDTO() { Id = CaseInput.Id },
                output: null);

            await useCase.Execute(CaseInput);
        });

        Assert.ThrowsAsync<UniqueEmailConstraintException>(async () =>
        {
            MakeRepositoryStub(
                input: new CustomerDTO() { Id = CaseInput.Id },
                output: Customer);
            MakeRepositoryStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: Customer);

            await useCase.Execute(CaseInput);
        });
    }
}
