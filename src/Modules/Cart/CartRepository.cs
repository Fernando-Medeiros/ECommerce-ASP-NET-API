namespace ECommerce.Modules.Cart;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public CartRepository(
        DatabaseContext context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
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
