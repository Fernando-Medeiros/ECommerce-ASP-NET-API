using System.Text.Json;

namespace Test.Setup.Fixtures;

public sealed class ResponseFixture
{
    public async Task<T?> Deserialize<T>(HttpResponseMessage response)
    {
        return JsonSerializer.Deserialize<T>(
                json: await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
