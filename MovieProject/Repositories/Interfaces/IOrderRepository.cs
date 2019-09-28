using movieproject.Models;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
