namespace ECommerceMail.Contract;

public abstract record BaseTemplate(
    string To,
    string Subject,
    string Template,
    object Model);



