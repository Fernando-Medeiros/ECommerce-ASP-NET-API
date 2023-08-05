namespace ECommerce.Modules.Cart;

using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Product;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CartService(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CartDTO> FindOne(int cartId, string customerId)
    {
        var cartEntity = await _cartRepository.FindOne(cartId, customerId)
            ?? throw new NotFoundError("Cart Not Found");

        return _mapper.Map<CartDTO>(cartEntity);
    }

    public async Task Register(CartDTO dto)
    {
        var _ = await _productRepository.FindOne(dto.ProductId)
            ?? throw new NotFoundError("Product Not Found");

        dto.CreatedAt = DateTime.UtcNow;

        var cartEntity = _mapper.Map<Cart>(dto);

        await _cartRepository.Create(cartEntity);
    }

    public async Task Update(CartDTO dto)
    {
        CartDTO cart = await FindOne(dto.Id, dto.CustomerId!);

        cart.Quantity = dto.Quantity;

        var cartEntity = _mapper.Map<Cart>(cart);

        await _cartRepository.Update(cartEntity);
    }

    public async Task Remove(CartDTO dto)
    {
        CartDTO cart = await FindOne(dto.Id, dto.CustomerId!);

        var cartEntity = _mapper.Map<Cart>(cart);

        await _cartRepository.Remove(cartEntity);
    }
}
