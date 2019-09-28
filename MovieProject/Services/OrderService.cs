using movieproject.Models;
using movieproject.Repositories.Interfaces;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        private readonly IOrderRepository _orderRepository;

        public OrderService(IShoppingCartRepository shoppingCartRepository, IOrderRepository orderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
        }
    }
}
