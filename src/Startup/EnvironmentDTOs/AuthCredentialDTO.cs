using dotenv.net.Utilities;

namespace ECommerce.Startup.EnvironmentDTOs
{
    public readonly struct AuthCredentialDTO
    {
        public readonly string PrivateKey;

        public readonly int TokenExpires;

        public AuthCredentialDTO()
        {
            PrivateKey = EnvReader.GetStringValue("PRIVATE_KEY");

            TokenExpires = EnvReader.GetIntValue("TOKEN_EXPIRES");
        }
    }
}