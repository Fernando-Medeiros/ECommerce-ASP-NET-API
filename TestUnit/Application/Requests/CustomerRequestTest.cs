using ECommerceApplication.Request;
using ECommerceCommon;

namespace TestUnit.Application.Requests;

public sealed class CustomerRequestTest
{
    [Theory]
    [InlineData("joh", "dee", "foo", "j@mail.com", "12345678")]
    [InlineData("john dee", "foo", "example", "example@mail.com", "example123")]
    public async void Should_Validate_Customer_Create_Request(
        string? name, string? firstName, string? lastName, string? email, string? password)
    {
        var request = new CustomerRequest()
        {
            Name = name,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await request.ValidateAsync();

        Assert.Equal(request.Name, name);
        Assert.Equal(request.FirstName, firstName);
        Assert.Equal(request.LastName, lastName);
        Assert.Equal(request.Email, email);
        Assert.Equal(request.Password, password);
    }

    [Theory]
    [InlineData(null, "", "dd")]
    [InlineData(null, "", "example example example")]
    public async void Should_Throw_Exception_On_Validate_Name(
        string? value1, string? value2, string? value3)
    {
        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Name = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Name = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Name = value3 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { FirstName = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { FirstName = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { FirstName = value3 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { LastName = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { LastName = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { LastName = value3 }.ValidateAsync());
    }

    [Theory]
    [InlineData(null, "", "55555", "@mail.com")]
    [InlineData(null, "", "22", "@m.com")]
    public async void Should_Throw_Exception_On_Validate_Email(
        string? value1, string? value2, string? value3, string value4)
    {
        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Email = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Email = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Email = value3 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Email = value4 }.ValidateAsync());
    }

    [Theory]
    [InlineData(null, "", "7777777", "example$$")]
    [InlineData(null, "", "22", "example**$#%,!")]
    public async void Should_Throw_Exception_On_Validate_Password(
        string? value1, string? value2, string? value3, string value4)
    {
        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Password = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Password = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Password = value3 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<CustomException>(async () =>
            await new CustomerRequest() { Password = value4 }.ValidateAsync());
    }
}
