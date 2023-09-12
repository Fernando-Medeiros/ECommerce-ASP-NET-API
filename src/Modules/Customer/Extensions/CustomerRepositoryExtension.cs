namespace ECommerce.Modules.Customer;

public static class CustomerRepositoryExtension
{
    public static async Task UniqueEmailConstraint(
        this ICustomerRepository repo, string? email)
    {
        if (await repo.Find(new() { Email = email }) is not null)
            throw new UniqueEmailConstraintException();
    }

    public static async Task<CustomerDTO> FindOneOrNotFound(
        this ICustomerRepository repo, CustomerDTO dto)
    {
        return await repo.Find(dto)
            ?? throw new NotFoundCustomerException();
    }
}
