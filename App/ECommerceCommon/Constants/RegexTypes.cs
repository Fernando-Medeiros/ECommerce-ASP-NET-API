namespace ECommerceCommon.Constants;

public static class RegexTypes
{
    public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public const string Name = @"^(?!.*([A-Za-zÀ-ÿ])\1\1)[A-Za-zÀ-ÿ]{3,18}(?: [A-Za-zÀ-ÿ]{3,18})?$";

    public const string Password = @"^(?=.*[a-zA-Z0-9çÇ@._-])[a-zA-Z0-9çÇ@._-]{8,16}$";

    public const string PasswordHash = @"^\$2[ayb]\$\d{2}\$[./A-Za-z0-9]{53}$";
}
