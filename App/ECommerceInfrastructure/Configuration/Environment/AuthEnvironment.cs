namespace ECommerceInfrastructure.Configuration.Environment
{
    public static class AuthEnvironment
    {
        public static string? PrivateKey { get; private set; }
        public static double AccessTokenExp { get; private set; }
        public static double RefreshTokenExp { get; private set; }
        public static double RecoverPasswordTokenExp { get; private set; }
        public static double AuthenticateEmailTokenExp { get; private set; }

        public static void LoadEnv(IConfiguration x)
        {
            PrivateKey = x.GetValue<string>("PRIVATE_KEY")!;
            AccessTokenExp = x.GetValue<double>("TOKEN_ACCESS_EXP");
            RefreshTokenExp = x.GetValue<double>("TOKEN_REFRESH_EXP");
            RecoverPasswordTokenExp = x.GetValue<double>("TOKEN_RECOVER_PASS_EXP");
            AuthenticateEmailTokenExp = x.GetValue<double>("TOKEN_AUTH_EMAIL_EXP");
        }
    }
}