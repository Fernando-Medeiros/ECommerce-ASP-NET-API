using dotenv.net.Utilities;

namespace ECommerce.Startup.EnvironmentDTOs;

public readonly struct DatabaseCredentialDTO
{
    public readonly string Host;
    public readonly string Database;
    public readonly string User;
    public readonly string Pass;

    public DatabaseCredentialDTO()
    {
        Host = EnvReader.GetStringValue("DB_HOST");
        Database = EnvReader.GetStringValue("DB_NAME");
        User = EnvReader.GetStringValue("DB_USER");
        Pass = EnvReader.GetStringValue("DB_PASS");
    }

    public static string GetDatabaseConnectionString()
    {
        var _ = new DatabaseCredentialDTO();

        return $"Server={_.Host};DataBase={_.Database};Uid={_.User};Pwd={_.Pass}";
    }
}