using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceCommon;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceInfrastructure.Auth;
using ECommerceTestSetup.Shared;
using NSubstitute;

namespace ECommerceTestIntegration.UseCase;

public sealed class RegisterCustomerTest : SharedCustomerTest
{
    readonly IUnitTransaction _transaction;
    readonly ICustomerMailEvent _mailEvent;
    readonly ICryptService _crypt;

    readonly RegisterCustomerRequest CaseInput;

    public RegisterCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransaction>();
        _mailEvent = Substitute.For<ICustomerMailEvent>();
        _crypt = new CryptService();
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
