using Microsoft.AspNetCore.Http;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using movieproject.Views.Movies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<bool> AddItemToCart(Movie movie, string cartId)
        {
            var success = false;
            var existingCartItem = await _shoppingCartRepository.GetOneAsync(movie, cartId);
            if(existingCartItem == null)
            {
                var newCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = cartId,
                    MovieId = movie.Id,
                    Quantity = 1,
                    OrderDate = DateTime.Now
                };
                await _shoppingCartRepository.AddAsync(newCartItem);
                success = true;
            }
            else
            {
                existingCartItem.Quantity++;
                await _shoppingCartRepository.UpdateAsync(existingCartItem);
                success = true;
            }

            return success;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContext httpContext)
        {
            if (!httpContext.Session.Keys.Any(k => k.Contains(CartSessionKey)))
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString(CartSessionKey, httpContext.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    httpContext.Session.SetString(CartSessionKey, tempCartId.ToString());

                    var x = httpContext.Session.GetString(CartSessionKey);
                }
            }

            return httpContext.Session.GetString(CartSessionKey);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetCurrentCart(string cartId)
        {
            var result = await _shoppingCartRepository.GetAllByCartId(cartId);
            return result;
        }

        public async Task<int> RemoveItemToCart(Movie movie, string cartId)
        {
            int itemQty = 0;
            var existingCartItem = await _shoppingCartRepository.GetOneAsync(movie, cartId);
            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity > 1)
                {
                    existingCartItem.Quantity--;
                    itemQty = existingCartItem.Quantity;
                    await _shoppingCartRepository.UpdateAsync(existingCartItem);
                }
                else
                {
                    await _shoppingCartRepository.RemoveAsync(cartId);
                }
            }
            return itemQty;
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllCartItems()
        {
            return await _shoppingCartRepository.GetAllAsync();
        }

        public async Task ClearCartAsync(string cartId)
        {
            await _shoppingCartRepository.RemoveAsync(cartId);
        }
    }
}
