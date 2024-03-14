using ECommerceDomain.DTO;
using ECommerceDomain.Entities;
using ECommerceTestSetup.Mocks;

namespace ECommerceTestUnit.Domain.Entities;

public class CustomerEntityTest
{
    readonly CustomerDTO CurrentState;
    readonly CustomerDTO DataToRegister;
    readonly CustomerDTO DataToUpdate;

    public CustomerEntityTest()
    {
        CustomerMocks Mock = new();

        CurrentState = Mock.CustomerDTO;
        DataToRegister = Mock.DataToRegister;
        DataToUpdate = Mock.DataToUpdate;
    }

    [Fact]
    public void Should_Register_New_Customer()
    {
        var entity = new Customer().Register(DataToRegister);

        Assert.NotNull(entity.Id);
        Assert.Equal(entity.Name?.Name, DataToRegister.Name);
        Assert.Equal(entity.Name?.FirstName, DataToRegister.FirstName);
        Assert.Equal(entity.Name?.LastName, DataToRegister.LastName);
        Assert.Equal(entity.Email, DataToRegister.Email);
        Assert.Equal(entity.Password, DataToRegister.Password);
    }

    [Fact]
    public void Should_Load_Current_State()
    {
        var entity = new Customer(CurrentState);

        Assert.Equal(entity.Id, CurrentState.Id);
        Assert.Equal(entity.Name?.Name, CurrentState.Name);
        Assert.Equal(entity.Name?.FirstName, CurrentState.FirstName);
        Assert.Equal(entity.Name?.LastName, CurrentState.LastName);
        Assert.Equal(entity.Email, CurrentState.Email);
        Assert.Equal(entity.Password, CurrentState.Password);
        Assert.StrictEqual(entity.CreatedOn, CurrentState.CreatedOn);
    }

    [Fact]
    public void Should_Update_Name()
    {
        var entity = new Customer(CurrentState).UpdateName(DataToUpdate);

        Assert.Equal(entity.Name?.Name, DataToUpdate.Name);
        Assert.Equal(entity.Name?.FirstName, DataToUpdate.FirstName);
        Assert.Equal(entity.Name?.LastName, DataToUpdate.LastName);
        Assert.True(entity.UpdatedOn < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Email()
    {
        var entity = new Customer(CurrentState).UpdateEmail(DataToUpdate);

        Assert.Equal(entity.Email, DataToUpdate.Email);
        Assert.True(entity.UpdatedOn < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Password()
    {
        var entity = new Customer(CurrentState).UpdatePassword(DataToUpdate);

        Assert.Equal(entity.Password, DataToUpdate.Password);
        Assert.True(entity.UpdatedOn < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Role()
    {
        var entity = new Customer(CurrentState).UpdateRole(DataToUpdate);

        Assert.Equal(entity.Role, DataToUpdate.Role);
        Assert.True(entity.UpdatedOn < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Assign_Verified()
    {
        var entity = new Customer(CurrentState).AssignVerified();

        Assert.True(entity.VerifiedOn < DateTimeOffset.UtcNow);
        Assert.True(entity.UpdatedOn < DateTimeOffset.UtcNow);
    }
}
