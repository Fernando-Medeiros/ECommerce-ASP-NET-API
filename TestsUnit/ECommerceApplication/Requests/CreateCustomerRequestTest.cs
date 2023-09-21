using ECommerceApplication.Requests;
using ECommerceDomain.Exceptions;

namespace TestsUnit.ECommerceApplication.Requests;

public class CreateCustomerRequestTest
{
    [Theory]
    [InlineData("joh", "dee", "foo", "j@mail.com", "12345678")]
    [InlineData("john dee", "foo", "example", "example@mail.com", "example123")]
    public async void Should_Validate_Customer_Create_Request(
        string? name, string? firstName, string? lastName, string? email, string? password)
    {
        var request = new CreateCustomerRequest()
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
    public void Should_Throw_Exception_On_Validate_Name(
        string? value1, string? value2, string? value3)
    {
        Assert.ThrowsAsync<NotNullException>(async () =>
            await new CreateCustomerRequest() { Name = value1 }.ValidateAsync());

        Assert.ThrowsAsync<NotEmptyException>(async () =>
            await new CreateCustomerRequest() { Name = value2 }.ValidateAsync());

        Assert.ThrowsAsync<LengthException>(async () =>
            await new CreateCustomerRequest() { Name = value3 }.ValidateAsync());

        Assert.ThrowsAsync<NotNullException>(async () =>
            await new CreateCustomerRequest() { FirstName = value1 }.ValidateAsync());

        Assert.ThrowsAsync<NotEmptyException>(async () =>
            await new CreateCustomerRequest() { FirstName = value2 }.ValidateAsync());

        Assert.ThrowsAsync<LengthException>(async () =>
            await new CreateCustomerRequest() { FirstName = value3 }.ValidateAsync());

        Assert.ThrowsAsync<NotNullException>(async () =>
            await new CreateCustomerRequest() { LastName = value1 }.ValidateAsync());

        Assert.ThrowsAsync<NotEmptyException>(async () =>
            await new CreateCustomerRequest() { LastName = value2 }.ValidateAsync());

        Assert.ThrowsAsync<LengthException>(async () =>
            await new CreateCustomerRequest() { LastName = value3 }.ValidateAsync());
    }

    [Theory]
    [InlineData(null, "", "55555", "@mail.com")]
    [InlineData(null, "", "22", "@m.com")]
    public void Should_Throw_Exception_On_Validate_Email(
        string? value1, string? value2, string? value3, string value4)
    {
        Assert.ThrowsAsync<NotNullException>(async () =>
            await new CreateCustomerRequest() { Email = value1 }.ValidateAsync());

        Assert.ThrowsAsync<NotEmptyException>(async () =>
            await new CreateCustomerRequest() { Email = value2 }.ValidateAsync());

        Assert.ThrowsAsync<LengthException>(async () =>
            await new CreateCustomerRequest() { Email = value3 }.ValidateAsync());

        Assert.ThrowsAsync<EmailFormatException>(async () =>
            await new CreateCustomerRequest() { Email = value4 }.ValidateAsync());
    }

    [Theory]
    [InlineData(null, "", "7777777", "example$$")]
    [InlineData(null, "", "22", "example**$#%,!")]
    public void Should_Throw_Exception_On_Validate_Password(
        string? value1, string? value2, string? value3, string value4)
    {
        Assert.ThrowsAsync<NotNullException>(async () =>
            await new CreateCustomerRequest() { Password = value1 }.ValidateAsync());

        Assert.ThrowsAsync<NotEmptyException>(async () =>
            await new CreateCustomerRequest() { Password = value2 }.ValidateAsync());

        Assert.ThrowsAsync<LengthException>(async () =>
            await new CreateCustomerRequest() { Password = value3 }.ValidateAsync());

        Assert.ThrowsAsync<PasswordFormatException>(async () =>
            await new CreateCustomerRequest() { Password = value4 }.ValidateAsync());
    }
}
