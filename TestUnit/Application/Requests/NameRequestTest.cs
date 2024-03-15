using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;

namespace TestUnit.Application.Requests;

public sealed class NameRequestTest
{
    [Theory]
    [InlineData("john", null, null)]
    [InlineData(null, "dee", null)]
    [InlineData(null, null, "foo")]
    [InlineData(null, null, null)]
    public async void Should_Validate_Customer_Update_Request(
            string? name, string? firstName, string? lastName)
    {
        var request = new NameRequest()
        {
            Name = name,
            FirstName = firstName,
            LastName = lastName,
        };

        await request.ValidateAsync(false);

        Assert.Equal(request.Name, name);
        Assert.Equal(request.FirstName, firstName);
        Assert.Equal(request.LastName, lastName);
    }

    [Theory]
    [InlineData("", "dd")]
    [InlineData("", "example example example")]
    public async void Should_Throw_Exception_On_Validate_Name(
        string? value1, string? value2)
    {
        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new NameRequest() { Name = value1 }.ValidateAsync(false));

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new NameRequest() { Name = value2 }.ValidateAsync(false));

        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new NameRequest() { FirstName = value1 }.ValidateAsync(false));

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new NameRequest() { FirstName = value2 }.ValidateAsync(false));

        await Assert.ThrowsAnyAsync<NotEmptyException>(async () =>
            await new NameRequest() { LastName = value1 }.ValidateAsync(false));

        await Assert.ThrowsAnyAsync<LengthException>(async () =>
            await new NameRequest() { LastName = value2 }.ValidateAsync(false));
    }
}
