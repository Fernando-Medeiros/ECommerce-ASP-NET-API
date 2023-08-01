namespace ECommerce_ASP_NET_API.Modules.Cart;

using AutoMapper;
using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Product;

public class CartService : ICartService
{
    private readonly ICartRepository _repository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CartService(
        ICartRepository repository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _repository = repository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CartDTO?> FindOne(int? id)
    {
        var cartEntity = await _repository.FindOne(id);

        return _mapper.Map<CartDTO>(cartEntity);
    }

    public async Task<CartDTO> Register(CartDTO Dto)
    {
        var _ = await _productRepository.FindOne(Dto.ProductId)
            ?? throw new NotFoundError("Product Not Found");

        Dto.CreatedAt = DateTime.UtcNow;

        var cartEntity = _mapper.Map<Cart>(Dto);

        await _repository.Create(cartEntity);

        return _mapper.Map<CartDTO>(cartEntity);
    }

    public async Task Update(CartDTO Dto)
    {
        var currentCartEntity = await _repository.FindOne(Dto.Id)
            ?? throw new NotFoundError("Cart Not Found");

        currentCartEntity.Quantity = (int)Dto.Quantity!;

        await _repository.Update(currentCartEntity);
    }

    public async Task Remove(CartDTO Dto)
    {
        var cartEntity = await _repository.FindOne(Dto.Id)
            ?? throw new NotFoundError("Cart Not Found");

        await _repository.Remove(cartEntity);
    }
}
