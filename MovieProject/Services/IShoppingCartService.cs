using Microsoft.AspNetCore.Http;
using movieproject.Models;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public interface IShoppingCartService
    {
        Task<bool> AddItemToCart(Movie movie, string cartId);

        string GetCartId(HttpContext httpContext);

        Task<IEnumerable<ShoppingCartItem>> GetCurrentCart(string cartId);

        Task<int> RemoveItemToCart(Movie movie, string cartId);

        Task<IEnumerable<ShoppingCartItem>> GetAllCartItems();

        Task ClearCartAsync(string cartId);        
    }
}
