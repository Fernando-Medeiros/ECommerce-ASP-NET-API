namespace ECommerceMailService.Contracts;

public record ITemplate(
    string To,
    string Subject,
    string Template,
    object Model);



