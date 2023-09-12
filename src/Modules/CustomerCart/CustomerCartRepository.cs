using AutoMapper;
using ECommerce.Context;
using ECommerce.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Modules.CustomerCart;

public class CustomerCartRepository : ICustomerCartRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public CustomerCartRepository(
        DatabaseContext context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartDTO?>> FindCarts(string id)
    {
        var customer = await _context.Customers
            .Include(c => c.Carts)
            .SingleOrDefaultAsync(c => c.Id == id);

        return customer?.Carts == null
            ? new List<CartDTO>()
            : _mapper.Map<IEnumerable<CartDTO>>(customer?.Carts);
    }

    public async Task<CartDTO?> FindOne(string cartId, string customerId)
    {
        var cart = await _context.Carts
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == cartId && c.CustomerId == customerId);

        return cart == null ? null : _mapper.Map<CartDTO>(cart);
    }

    public async Task Register(CartCreateDTO dto)
    {
        var cartEntity = _mapper.Map<Cart>(dto);

        _context.Add(cartEntity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(CartDTO dto)
    {
        var cartEntity = _mapper.Map<Cart>(dto);

        _context.Update(cartEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(CartDTO dto)
    {
        var cartEntity = _mapper.Map<Cart>(dto);

        _context.Remove(cartEntity);

        await _context.SaveChangesAsync();
    }
}
