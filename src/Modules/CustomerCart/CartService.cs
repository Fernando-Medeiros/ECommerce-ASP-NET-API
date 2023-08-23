namespace ECommerce.Modules.CustomerCart;

using ECommerce.Exceptions;
using ECommerce.Modules.Product;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    private readonly IProductService _productService;

    public CartService(
        ICartRepository cartRepository,
        IProductService productService)
    {
        _cartRepository = cartRepository;
        _productService = productService;
    }

    public async Task<IEnumerable<CartDTO?>> FindCarts(string id)
    {
        return await _cartRepository.FindCarts(id);
    }

    public async Task<CartDTO> FindOne(string cartId, string customerId)
    {
        return await _cartRepository.FindOne(cartId, customerId)
            ?? throw new NotFoundError("Cart Not Found");
    }

    public async Task Register(CartCreateDTO dto)
    {
        ProductDTO product = await _productService.FindOne(id: dto.ProductId);

        if (dto.Quantity > product.Stock)
            throw new BadRequestError("Quantity greater than available stock");

        await _cartRepository.Register(dto);
    }

    public async Task Update(CartUpdateDTO dto)
    {
        CartDTO cart = await FindOne(dto.Id!, dto.CustomerId!);

        ProductDTO product = await _productService.FindOne(id: cart.ProductId);

        if (dto.Quantity > product.Stock)
            throw new BadRequestError("Quantity greater than available stock");

        dto.UpdateProperties(ref cart);

        await _cartRepository.Update(cart);
    }

    public async Task Remove(string cartId, string customerId)
    {
        CartDTO cart = await FindOne(cartId, customerId);

        await _cartRepository.Remove(cart);
    }
}
