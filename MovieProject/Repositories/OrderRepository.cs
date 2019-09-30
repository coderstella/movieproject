using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using movieproject.Database;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using movieproject.Services;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MovieContext _context;

        private readonly IUserRepository _userRepository;

        public OrderRepository(MovieContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public async Task AddAsync(Order order)
        {
            
            _context.Orders.Add(order);
            _context.Entry<ApplicationUser>(order.User).State = EntityState.Unchanged;
            _context.Entry(order.ShippingAddress.User).State = EntityState.Unchanged;
            //_context.Entry(order.ShippingAddress).State = order.ShippingAddress.Id == 0 ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
