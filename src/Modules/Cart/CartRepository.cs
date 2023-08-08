namespace ECommerce.Modules.Cart;

using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly DatabaseContext _context;

    public CartRepository(DatabaseContext context) => _context = context;

    public async Task<Cart?> FindOne(int cartId, string customerId)
    {
        return await _context.Carts
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == cartId && c.CustomerId == customerId);
    }

    public async Task Create(Cart cart)
    {
        _context.Add(cart);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Cart cart)
    {
        _context.Update(cart).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(Cart cart)
    {
        _context.Remove(cart);

        await _context.SaveChangesAsync();
    }
}
