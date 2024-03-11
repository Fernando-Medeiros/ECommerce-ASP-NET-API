using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceDomain.DTO;
using NSubstitute;
using TestSetup.Shared;
using ECommerceApplication.Contract;
using ECommerceCommon;

namespace TestIntegration.UseCase;

public sealed class UpdateCustomerTest : SharedCustomerTest
{
    readonly IUnitTransaction _transaction;

    readonly UpdateCustomerRequest CaseInput;

    public UpdateCustomerTest()
    {
        _transaction = Substitute.For<IUnitTransaction>();

        CaseInput = Mock.UpdateRequest;
    }

    [Fact]
    public async void Should_Update_Customer_NameOrEmail()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Mock.UniqueId },
            output: Mock.CustomerDTO);
        MakeRepositoryStub(
            input: new CustomerDTO() { Email = CaseInput.Email },
            output: null);

        var useCase = new UpdateCustomerNameAndEmail(
            _repository,
            _transaction);

        await useCase.Execute(CaseInput);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new UpdateCustomerNameAndEmail(
            _repository,
            _transaction);

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
        {
            var invalidCaseInput = CaseInput with { Email = "$$$@mail.com" };

            await useCase.Execute(invalidCaseInput);
        });

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: new CustomerDTO() { Id = Mock.UniqueId },
                output: null);

            await useCase.Execute(CaseInput);
        });

        await Assert.ThrowsAnyAsync<UniqueEmailConstraintException>(async () =>
        {
            MakeRepositoryStub(
                input: new CustomerDTO() { Id = Mock.UniqueId },
                output: Mock.CustomerDTO);
            MakeRepositoryStub(
                input: new CustomerDTO() { Email = CaseInput.Email },
                output: Mock.CustomerDTO);

            await useCase.Execute(CaseInput);
        });
    }
}
