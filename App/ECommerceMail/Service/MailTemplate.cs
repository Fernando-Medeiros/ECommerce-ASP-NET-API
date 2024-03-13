namespace ECommerceMail.Service;

public sealed record MailTemplate(
    string To,
    string Subject,
    string Template,
    object Model);



