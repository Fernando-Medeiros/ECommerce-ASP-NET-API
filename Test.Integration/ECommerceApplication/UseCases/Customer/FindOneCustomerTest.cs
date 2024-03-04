using ECommerceCommon.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class FindOneCustomerTest : SharedCustomerTest
{
    readonly CustomerDTO CaseInput;

    public FindOneCustomerTest()
    {
        CaseInput = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Return_One_Customer()
    {
        MakeRepositoryStub(
            input: CaseInput,
            output: Mock.CustomerDTO);

        var useCase = new FindOneCustomer(_repository);

        var result = await useCase.Execute(CaseInput);

        Assert.Equivalent(Mock.CustomerDTO, result);
    }

    [Fact]
    public async void Should_Throw_Exception()
    {
        var useCase = new FindOneCustomer(_repository);

        await Assert.ThrowsAnyAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: CaseInput,
                output: null);

            _ = await useCase.Execute(CaseInput);
        });
    }
}
