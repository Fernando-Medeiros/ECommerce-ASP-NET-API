namespace ECommerce.Startup.Environment
{
    public static class AuthCredential
    {
        public static string? PrivateKey { get; set; }
        public static double AccessTokenExp { get; set; }
        public static double RefreshTokenExp { get; set; }
        public static double RecoverPasswordTokenExp { get; set; }
        public static double AuthenticateEmailTokenExp { get; set; }

        public static void LoadEnv(IConfiguration conf)
        {
            PrivateKey = conf.GetValue<string>("PRIVATE_KEY")!;

            AccessTokenExp = conf.GetValue<double>("TOKEN_ACCESS_EXP");
            RefreshTokenExp = conf.GetValue<double>("TOKEN_REFRESH_EXP");
            RecoverPasswordTokenExp = conf.GetValue<double>("TOKEN_RECOVER_PASS_EXP");
            AuthenticateEmailTokenExp = conf.GetValue<double>("TOKEN_AUTH_EMAIL_EXP");
        }
    }
}