using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceDomain.DTO;
using ECommerceInfrastructure.Auth.Crypt;
using NSubstitute;
using TestSetup.Shared;
using ECommerceCommon;

namespace TestIntegration.UseCase;

public sealed class RegisterCustomerTest : SharedCustomerTest
{
    readonly IUnitTransaction _transaction;
    readonly ICustomerMailEvent _mailEvent;
    readonly ICryptPassword _crypt;

    readonly CreateCustomerRequest CaseInput;

    public RegisterCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransaction>();
        _mailEvent = Substitute.For<ICustomerMailEvent>();
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
            _mailEvent,
            _crypt);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new RegisterCustomer(
            _repository,
            _transaction,
            _mailEvent,
            _crypt);

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
        {
            var invalidCaseInput = CaseInput with { Email = "$$$@mail.com" };

            await useCase.Execute(invalidCaseInput);
        });

        await Assert.ThrowsAnyAsync<UniqueEmailConstraintException>(async () =>
        {
            MakeRepositoryStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: Mock.CustomerDTO);

            await useCase.Execute(CaseInput);
        });
    }
}
