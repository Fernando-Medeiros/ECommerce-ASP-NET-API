using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;

namespace Test.Unit.ECommerceApplication.Requests;

public class UpdateCustomerRequestTest
{
    [Theory]
    [InlineData("john", null, null, null)]
    [InlineData(null, "dee", null, null)]
    [InlineData(null, null, "foo", null)]
    [InlineData(null, null, null, "example@mail.com")]
    public async void Should_Validate_Customer_Update_Request(
            string? name, string? firstName, string? lastName, string? email)
    {
        var request = new UpdateCustomerRequest()
        {
            Name = name,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
        };

        await request.ValidateAsync();

        Assert.Equal(request.Name, name);
        Assert.Equal(request.FirstName, firstName);
        Assert.Equal(request.LastName, lastName);
        Assert.Equal(request.Email, email);
    }

    [Theory]
    [InlineData("", "dd")]
    [InlineData("", "example example example")]
    public async void Should_Throw_Exception_On_Validate_Name(
        string? value1, string? value2)
    {
        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new UpdateCustomerRequest() { Name = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new UpdateCustomerRequest() { Name = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new UpdateCustomerRequest() { FirstName = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new UpdateCustomerRequest() { FirstName = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new UpdateCustomerRequest() { LastName = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new UpdateCustomerRequest() { LastName = value2 }.ValidateAsync());
    }

    [Theory]
    [InlineData("", "55555", "@mail.com")]
    [InlineData("", "22", "@m.com")]
    public async void Should_Throw_Exception_On_Validate_Email(
        string? value1, string? value2, string? value3)
    {
        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new UpdateCustomerRequest() { Email = value1 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new UpdateCustomerRequest() { Email = value2 }.ValidateAsync());

        await Assert.ThrowsAnyAsync<EmailFormatException>(async () =>
            await new UpdateCustomerRequest() { Email = value3 }.ValidateAsync());
    }
}
