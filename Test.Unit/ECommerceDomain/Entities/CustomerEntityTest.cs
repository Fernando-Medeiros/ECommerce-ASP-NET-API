using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;
using Test.Setup.Mocks;

namespace Test.Unit.ECommerceDomain.Entities;

public class CustomerEntityTest
{
    private readonly CustomerDTO CurrentState = CustomerMocks.Customer;

    private readonly CustomerDTO DataToRegister = CustomerMocks.DataToRegister;

    private readonly CustomerDTO DataToUpdate = CustomerMocks.DataToUpdate;

    [Fact]
    public void Should_Register_New_Customer()
    {
        var en = new CustomerEntity().Register(DataToRegister);

        Assert.NotNull(en.Id?.Value);
        Assert.Equal(en.Name!.Name, DataToRegister.Name);
        Assert.Equal(en.Name!.FirstName, DataToRegister.FirstName);
        Assert.Equal(en.Name!.LastName, DataToRegister.LastName);
        Assert.Equal(en.Email!, DataToRegister.Email);
        Assert.Equal(en.Password!, DataToRegister.Password);
    }

    [Fact]
    public void Should_Load_Current_State()
    {
        var en = new CustomerEntity(CurrentState);

        Assert.Equal(en.Id!, CurrentState.Id);
        Assert.Equal(en.Name!.Name, CurrentState.Name);
        Assert.Equal(en.Name!.FirstName, CurrentState.FirstName);
        Assert.Equal(en.Name!.LastName, CurrentState.LastName);
        Assert.Equal(en.Email!, CurrentState.Email);
        Assert.Equal(en.Password!, CurrentState.Password);
        Assert.StrictEqual(en.CreatedOn!, CurrentState.CreatedOn);
    }

    [Fact]
    public void Should_Update_Name()
    {
        var en = new CustomerEntity(CurrentState).UpdateName(DataToUpdate);

        Assert.Equal(en.Name!.Name, DataToUpdate.Name);
        Assert.Equal(en.Name!.FirstName, DataToUpdate.FirstName);
        Assert.Equal(en.Name!.LastName, DataToUpdate.LastName);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Email()
    {
        var en = new CustomerEntity(CurrentState).UpdateEmail(DataToUpdate);

        Assert.Equal(en.Email!, DataToUpdate.Email);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Password()
    {
        var en = new CustomerEntity(CurrentState).UpdatePassword(DataToUpdate);

        Assert.Equal(en.Password!, DataToUpdate.Password);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Role()
    {
        var en = new CustomerEntity(CurrentState).UpdateRole(DataToUpdate);

        Assert.Equal(en.Role!, DataToUpdate.Role);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Assign_Verified()
    {
        var en = new CustomerEntity(CurrentState).AssignVerified();

        Assert.True(en.VerifiedOn! < DateTimeOffset.UtcNow);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }
}
