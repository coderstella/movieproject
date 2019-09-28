using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories.Interfaces
{
    public interface IShippingAddressRepository
    {
        Task AddAsync(ShippingAddress shippingAddress);
    }
}
