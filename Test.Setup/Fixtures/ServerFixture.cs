using ECommerceApplication.Contracts;
using ECommerceInfrastructure;
using ECommerceInfrastructure.Persistence.Repositories;
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
        var builder = new WebHostBuilder()
            .UseStartup<Startup>()
            .ConfigureTestServices(x =>
                x.AddSingleton<IUnitTransactionWork, UnitTransactionWork>());

        if (serviceOverride is Action<IServiceCollection>)
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