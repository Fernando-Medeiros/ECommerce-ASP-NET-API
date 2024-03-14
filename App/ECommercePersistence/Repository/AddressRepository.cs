using AutoMapper;
using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommercePersistence.Context;
using ECommercePersistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommercePersistence.Repository;

public sealed class AddressRepository(
    DatabaseContext context,
    IMapper mapper
    ) : IAddressRepository
{
    readonly IMapper _mapper = mapper;
    readonly DatabaseContext _context = context;

    public async Task<IEnumerable<AddressDTO>> FindMany(
        AddressDTO request,
        CancellationToken cancellationToken)
    {
        var addresses = await _context.Addresses
            .AsNoTracking()
            .Where(x => x.CustomerId == request.CustomerId)
            .ToArrayAsync();

        return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
    }

    public async Task<AddressDTO?> Find(
            AddressDTO request,
            CancellationToken cancellationToken)
    {
        var address = await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<AddressDTO?>(address);
    }

    public void Register(AddressDTO address)
    {
        var entity = _mapper.Map<Address>(address);

        _context.Addresses.Add(entity);
    }

    public void Remove(AddressDTO address)
    {
        var entity = _mapper.Map<Address>(address);

        _context.Addresses.Remove(entity);
    }

    public void Update(AddressDTO address)
    {
        var entity = _mapper.Map<Address>(address);

        _context.Addresses.Entry(entity).State = EntityState.Modified;
    }
}
