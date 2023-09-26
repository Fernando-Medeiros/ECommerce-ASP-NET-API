using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public class RemoveCustomerTest
{
    readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();
    readonly IUnitTransactionWork _transaction = Substitute.For<IUnitTransactionWork>();

    readonly CustomerDTO CaseInput = new() { Id = CustomerMocks.Customer.Id };

    private void CreateStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.FindOne(Arg.Is(input)).Returns(output);
    }

    [Fact]
    public async void Should_Remove_Customer()
    {
        CreateStub(
            input: CaseInput,
            output: CustomerMocks.Customer);

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
            CreateStub(
                input: CaseInput,
                output: null);

            await useCase.Execute(CaseInput);
        });
    }
}
