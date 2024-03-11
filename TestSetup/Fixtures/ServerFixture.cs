using ECommerceAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace TestSetup.Fixtures;

public class ServerFixture : IDisposable
{
    protected readonly TestServer _server;

    public readonly HttpClient Client;

    public ServerFixture(Action<IServiceCollection>? serviceOverride = null)
    {
        var _builder = new WebHostBuilder().UseStartup<Startup>();

        if (serviceOverride is Action<IServiceCollection>)
        {
            _builder.ConfigureTestServices(serviceOverride);
        }

        _server = new TestServer(_builder);

        Client = _server.CreateClient();
    }

    public virtual void Dispose()
    {
        Client.Dispose();
        _server.Dispose();
    }
}