using movieproject.Database;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories
{
    public class ShippingAddressRepository : IShippingAddressRepository
    {
        private readonly MovieContext _context;

        public ShippingAddressRepository(MovieContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ShippingAddress shippingAddress)
        {
            //_context.sh.Add(shippingAddress);
            await _context.SaveChangesAsync();
        }
    }
}
