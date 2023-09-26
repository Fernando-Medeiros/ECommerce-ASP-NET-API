using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.Abstractions;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Authentication.Encrypt;
using NSubstitute;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public class RegisterCustomerTest
{
    readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();
    readonly IUnitTransactionWork _transaction = Substitute.For<IUnitTransactionWork>();
    readonly ICryptPassword _crypt = new CryptPassword();

    readonly CreateCustomerRequest CaseInput = CustomerMocks.CreateRequest;

    private void CreateStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.FindOne(Arg.Is(input)).Returns(output);
    }

    [Fact]
    public async void Should_Register_Customer()
    {
        CreateStub(
            input: new CustomerDTO() { Email = CaseInput.Email },
            output: null);

        var useCase = new RegisterCustomer(
            _repository,
            _transaction,
            _crypt);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new RegisterCustomer(
            _repository,
            _transaction,
            _crypt);

        Assert.ThrowsAsync<DomainException>(async () =>
        {
            var invalidCaseInput = CaseInput with { Email = "$$$@mail.com" };

            await useCase.Execute(invalidCaseInput);
        });

        Assert.ThrowsAsync<UniqueEmailConstraintException>(async () =>
        {
            CreateStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: CustomerMocks.Customer);

            await useCase.Execute(CaseInput);
        });
    }
}
