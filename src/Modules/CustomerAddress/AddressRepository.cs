namespace ECommerce.Modules.CustomerAddress;

using AutoMapper;
using ECommerce.Context;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

public class AddressRepository : IAddressRepository
{
    private readonly DatabaseContext _context;

    private readonly IMapper _mapper;

    public AddressRepository(DatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDTO?>> FindAddresses(string customerId)
    {
        var customer = await _context.Customers
            .Include(c => c.Addresses)
            .SingleOrDefaultAsync(c => c.Id == customerId);

        return customer?.Addresses == null
            ? new List<AddressDTO>()
            : _mapper.Map<IEnumerable<AddressDTO>>(customer!.Addresses);
    }

    public async Task<AddressDTO?> FindOne(string addressId, string customerId)
    {
        Address? result = null;

        result = await _context.Addresses
            .AsNoTracking()
            .Where(a => a.Id == addressId && a.CustomerId == customerId)
            .FirstOrDefaultAsync();

        return result == null
            ? null
            : _mapper.Map<AddressDTO>(result);
    }

    public async Task Register(AddressCreateDTO dto)
    {
        var addressEntity = _mapper.Map<Address>(dto);

        _context.Addresses.Add(addressEntity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(AddressDTO dto)
    {
        var addressEntity = _mapper.Map<Address>(dto);

        _context.Addresses.Entry(addressEntity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task Remove(AddressDTO dto)
    {
        var addressEntity = _mapper.Map<Address>(dto);

        _context.Addresses.Remove(addressEntity);

        await _context.SaveChangesAsync();
    }
}