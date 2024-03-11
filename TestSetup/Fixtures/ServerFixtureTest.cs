using System.Net;

namespace TestSetup.Fixtures;

public class ServerFixtureTest
{
    [Fact]
    public async void Should_Build_ServerFixture_And_Make_A_Request()
    {
        using var app = new ServerFixture();

        var response = await app.Client.GetAsync("/");

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
    }
}
