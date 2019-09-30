using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieproject.Database;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using movieproject.Views.Movies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly MovieContext _context;
        public ShoppingCartRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ShoppingCartItem shoppingCartItem)
        {
            _context.ShoppingCartItems.Add(shoppingCartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShoppingCartItem shoppingCartItem)
        {
            _context.Entry<Movie>(shoppingCartItem.Movie).State = EntityState.Unchanged;
            _context.ShoppingCartItems.Update(shoppingCartItem);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ShoppingCartItem>> GetAllByCartId(string cartId)
        {
            var cartItems = await _context.ShoppingCartItems.Include(c => c.Movie).Where(c => c.ShoppingCartId == cartId).ToListAsync();
            return cartItems;
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllAsync()
        {
            var result = await _context.ShoppingCartItems.ToListAsync();
            return result;
        }

        public async Task<ShoppingCartItem> GetOneAsync(Movie movie, string shoppingCartId)
        {
            var result = await _context.ShoppingCartItems.SingleOrDefaultAsync(c => c.ShoppingCartId == shoppingCartId && c.MovieId == movie.Id);
            return result;
        }

        public async Task RemoveAsync(string shoppingCartId)
        {
            var selectedCart = _context.ShoppingCartItems.SingleOrDefault(c => c.ShoppingCartId == shoppingCartId);
            _context.ShoppingCartItems.Remove(selectedCart);
            await _context.SaveChangesAsync();
        }
    }
}
