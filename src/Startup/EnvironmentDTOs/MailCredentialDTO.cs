using dotenv.net.Utilities;

namespace ECommerce.Startup.EnvironmentDTOs;

public readonly struct MailCredentialDTO
{
    public readonly string User;
    public readonly string Pass;
    public readonly string Host;
    public readonly int Port;
    public readonly bool Encryption;
    public readonly string FromName;
    public readonly string FromAddress;

    public MailCredentialDTO()
    {
        User = EnvReader.GetStringValue("MAIL_USER");
        Pass = EnvReader.GetStringValue("MAIL_PASS");
        Host = EnvReader.GetStringValue("MAIL_HOST");
        Port = EnvReader.GetIntValue("MAIL_PORT");
        Encryption = EnvReader.GetBooleanValue("MAIL_ENCRYPTION");
        FromName = EnvReader.GetStringValue("MAIL_FROM_NAME");
        FromAddress = EnvReader.GetStringValue("MAIL_FROM_ADDRESS");
    }
}
