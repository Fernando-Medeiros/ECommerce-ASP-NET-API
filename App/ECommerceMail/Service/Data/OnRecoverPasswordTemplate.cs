using ECommerceMail.Contract;
using ECommerceMail.Template;

namespace ECommerceMail.Service.Data;

public sealed record OnRecoverPasswordTemplate : BaseTemplate
{
    public OnRecoverPasswordTemplate(
        string To,
        RecoverPasswordVM Model)
        : base(To, "Recover Password", "RecoverPassword", Model) { }
}
