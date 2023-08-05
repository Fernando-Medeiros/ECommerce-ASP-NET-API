namespace ECommerce.Modules.Cart;

using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Product;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public CartService(
        ICartRepository cartRepository,
        IProductService productService,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productService = productService;
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
        var product = await _productService.FindOne(id: dto.ProductId);

        if (dto.Quantity > product.Stock)
            throw new BadRequestError("Quantity greater than available stock");

        dto.CreatedAt = DateTime.UtcNow;

        var cartEntity = _mapper.Map<Cart>(dto);

        await _cartRepository.Create(cartEntity);
    }

    public async Task Update(CartDTO dto)
    {
        var cart = await FindOne(dto.Id, dto.CustomerId!);

        var product = await _productService.FindOne(id: cart.ProductId);

        if (dto.Quantity > product.Stock)
            throw new BadRequestError("Quantity greater than available stock");

        cart.Quantity = dto.Quantity;

        var cartEntity = _mapper.Map<Cart>(cart);

        await _cartRepository.Update(cartEntity);
    }

    public async Task Remove(CartDTO dto)
    {
        var cart = await FindOne(dto.Id, dto.CustomerId!);

        var cartEntity = _mapper.Map<Cart>(cart);

        await _cartRepository.Remove(cartEntity);
    }
}
