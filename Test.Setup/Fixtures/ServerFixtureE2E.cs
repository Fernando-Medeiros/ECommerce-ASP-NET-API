using ECommercePersistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Setup.Fixtures;

public sealed class ServerFixtureE2E : ServerFixture
{
    readonly DatabaseContext _context;

    public ServerFixtureE2E() : base()
    {
        _context = _server.Services.GetService<DatabaseContext>()!;
    }

    public async Task InsertOneAsync<T>(T entity) where T : class
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }
}