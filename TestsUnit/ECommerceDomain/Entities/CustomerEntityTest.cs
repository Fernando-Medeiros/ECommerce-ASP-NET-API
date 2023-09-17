using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;
using ECommerceDomain.Enums;

namespace TestsUnit.ECommerceDomain.Entities;

public class CustomerEntityTest
{
    private readonly CustomerDTO currentState = new()
    {
        Id = Guid.NewGuid().ToString(),
        Name = "John",
        FirstName = "dee",
        LastName = "dee",
        Email = "example@mail.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test123"),
        Role = nameof(ERoles.customer),
        CreatedOn = DateTimeOffset.UtcNow
    };

    private readonly CustomerDTO data = new()
    {
        Name = "John dee",
        FirstName = "foo",
        LastName = "woodcutter",
        Email = "john_dee@mail.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test777")
    };


    [Fact]
    public void Should_Register_New_Customer()
    {
        var en = new CustomerEntity().Register(data);

        Assert.NotNull(en.Id?.Value);
        Assert.Equal(en.Name!.Name, data.Name);
        Assert.Equal(en.Name!.FirstName, data.FirstName);
        Assert.Equal(en.Name!.LastName, data.LastName);
        Assert.Equal(en.Email!, data.Email);
        Assert.Equal(en.Password!, data.Password);
    }

    [Fact]
    public void Should_Load_Current_State()
    {
        var en = new CustomerEntity(currentState);

        Assert.Equal(en.Id!, currentState.Id);
        Assert.Equal(en.Name!.Name, currentState.Name);
        Assert.Equal(en.Name!.FirstName, currentState.FirstName);
        Assert.Equal(en.Name!.LastName, currentState.LastName);
        Assert.Equal(en.Email!, currentState.Email);
        Assert.Equal(en.Password!, currentState.Password);
        Assert.StrictEqual(en.CreatedOn!, currentState.CreatedOn);
    }

    [Fact]
    public void Should_Update_Name()
    {
        var en = new CustomerEntity(currentState).UpdateName(data);

        Assert.Equal(en.Name!.Name, data.Name);
        Assert.Equal(en.Name!.FirstName, data.FirstName);
        Assert.Equal(en.Name!.LastName, data.LastName);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Email()
    {
        var en = new CustomerEntity(currentState).UpdateEmail(data);

        Assert.Equal(en.Email!, data.Email);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Password()
    {
        var en = new CustomerEntity(currentState).UpdatePassword(data);

        Assert.Equal(en.Password!, data.Password);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Update_Role()
    {
        var en = new CustomerEntity(currentState).UpdateRole(data);

        Assert.Equal(en.Role!, data.Role);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }

    [Fact]
    public void Should_Assign_Verified()
    {
        var en = new CustomerEntity(currentState).AssignVerified();

        Assert.True(en.VerifiedOn! < DateTimeOffset.UtcNow);
        Assert.True(en.UpdatedOn! < DateTimeOffset.UtcNow);
    }
}
