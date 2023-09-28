using ECommerceInfrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Setup.Fixtures;

public class ServerFixture : IDisposable
{
    protected readonly TestServer _server;

    public readonly HttpClient Client;

    public ServerFixture(Action<IServiceCollection>? serviceOverride = null)
    {
        var builder = new WebHostBuilder().UseStartup<Startup>();

        if (serviceOverride is not null)
        {
            builder.ConfigureTestServices(serviceOverride);
        }

        _server = new TestServer(builder);

        Client = _server.CreateClient();
    }

    public virtual void Dispose()
    {
        Client.Dispose();
        _server.Dispose();
    }
}