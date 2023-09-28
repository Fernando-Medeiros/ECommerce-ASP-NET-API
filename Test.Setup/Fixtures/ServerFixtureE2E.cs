using ECommerceInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Setup.Fixtures;

public enum ETable
{
    customer = 0
}

public sealed class ServerFixtureE2E : ServerFixture
{
    readonly DatabaseContext _context;

    readonly ETable _table;

    public ServerFixtureE2E(ETable table) : base()
    {
        _table = table;
        _context = _server.Services.GetService<DatabaseContext>()!;
    }

    public override async void Dispose()
    {
        await TruncateTablesAsync();
        base.Dispose();
    }

    public async Task InsertOneAsync<T>(T entity) where T : class
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    private async Task TruncateTablesAsync()
    {
        var _ = _table switch
        {
            ETable.customer => await _context.Customers.ExecuteDeleteAsync(),
            _ => 0
        };
        await _context.SaveChangesAsync();
    }
}