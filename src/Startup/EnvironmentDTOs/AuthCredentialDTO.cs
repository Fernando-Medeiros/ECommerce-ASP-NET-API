using dotenv.net.Utilities;

namespace ECommerce.Startup.EnvironmentDTOs
{
    public readonly struct AuthCredentialDTO
    {
        public readonly string PrivateKey;

        public readonly double AccessTokenExp;
        public readonly double RefreshTokenExp;
        public readonly double RecoverPasswordTokenExp;
        public readonly double AuthenticateEmailTokenExp;

        public AuthCredentialDTO()
        {
            PrivateKey = EnvReader.GetStringValue("PRIVATE_KEY");

            AccessTokenExp = EnvReader.GetDoubleValue("TOKEN_ACCESS_EXP");
            RefreshTokenExp = EnvReader.GetDoubleValue("TOKEN_REFRESH_EXP");
            RecoverPasswordTokenExp = EnvReader.GetDoubleValue("TOKEN_RECOVER_PASS_EXP");
            AuthenticateEmailTokenExp = EnvReader.GetDoubleValue("TOKEN_AUTH_EMAIL_EXP");
        }
    }
}