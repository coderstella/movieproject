using movieproject.Models;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task AddAsync(ShoppingCartItem shoppingCartItem);

        Task UpdateAsync(ShoppingCartItem shoppingCartItem);

        Task<IEnumerable<ShoppingCartItem>> GetAllByCartId(string cartId);

        Task<IEnumerable<ShoppingCartItem>> GetAllAsync();

        Task<ShoppingCartItem> GetOneAsync(Movie movie, string shoppingCartId);

        Task RemoveAsync(string shoppingCartId);
    }
}
