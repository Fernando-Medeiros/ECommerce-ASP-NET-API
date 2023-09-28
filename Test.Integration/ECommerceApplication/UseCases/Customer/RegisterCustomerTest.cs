using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.Abstractions;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Authentication.Encrypt;
using NSubstitute;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class RegisterCustomerTest : SharedCustomerTest
{
    readonly IUnitTransactionWork _transaction;

    readonly ICryptPassword _crypt;

    readonly CreateCustomerRequest CaseInput;

    public RegisterCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransactionWork>();
        _crypt = new CryptPassword();
        CaseInput = Mock.CreateRequest;
    }

    [Fact]
    public async void Should_Register()
    {
        MakeRepositoryStub(
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
            MakeRepositoryStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: Mock.CustomerDTO);

            await useCase.Execute(CaseInput);
        });
    }
}
