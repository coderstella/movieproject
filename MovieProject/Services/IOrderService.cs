using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
    }
}
