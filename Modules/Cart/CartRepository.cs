namespace ECommerce_ASP_NET_API.Modules.Cart;

using ECommerce_ASP_NET_API.Context;
using ECommerce_ASP_NET_API.Models;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly DatabaseContext _context;
    public CartRepository(DatabaseContext context) => _context = context;

    public async Task<Cart?> FindOne(int? id)
    {
        return await _context.Carts
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cart> Create(Cart cart)
    {
        _context.Add(cart);

        await _context.SaveChangesAsync();

        return cart;
    }

    public async Task<Cart> Update(Cart cart)
    {
        _context.Update(cart).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return cart;
    }

    public async Task<Cart> Remove(Cart cart)
    {
        _context.Remove(cart);

        await _context.SaveChangesAsync();

        return cart;
    }
}
