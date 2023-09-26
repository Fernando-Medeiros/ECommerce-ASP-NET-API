using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.Abstractions;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public class UpdateCustomerNameAndEmailTest
{
    readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();
    readonly IUnitTransactionWork _transaction = Substitute.For<IUnitTransactionWork>();

    readonly UpdateCustomerRequest CaseInput = CustomerMocks.UpdateRequest;

    private void CreateStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.FindOne(Arg.Is(input)).Returns(output);
    }

    [Fact]
    public async void Should_Update_Customer_NameOrEmail()
    {
        CreateStub(
            input: new CustomerDTO() { Id = CaseInput.Id },
            output: CustomerMocks.Customer);
        CreateStub(
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
            CreateStub(
                input: new CustomerDTO() { Id = CaseInput.Id },
                output: null);

            await useCase.Execute(CaseInput);
        });

        Assert.ThrowsAsync<UniqueEmailConstraintException>(async () =>
        {
            CreateStub(
                input: new CustomerDTO() { Id = CaseInput.Id },
                output: CustomerMocks.Customer);
            CreateStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: CustomerMocks.Customer);

            await useCase.Execute(CaseInput);
        });
    }
}
