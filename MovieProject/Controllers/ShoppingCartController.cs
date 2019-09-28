using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieproject.Data;
using movieproject.Models;
using movieproject.Services;
using movieproject.ViewModels;

namespace movieproject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MovieContext _context;

        private readonly IMovieLibraryService _movieLibraryService;

        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IMovieLibraryService movieLibraryService, MovieContext context, IShoppingCartService shoppingCartService)
        {
            _movieLibraryService = movieLibraryService;
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        // GET: /ShoppingCart/
        public async Task<IActionResult> Index()
        {
            var cartId = _shoppingCartService.GetCartId(this.HttpContext);
            var cartItems = await _shoppingCartService.GetCurrentCart(cartId);
            var totalAmout = cartItems.Sum(c => c.Quantity * c.Movie.Price);
    
            var viewMovel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                ShoppingCartTotal = totalAmout
            };

            return View(viewMovel);
            
        }

        // GET: /Movies/AddToCart/1
        public async Task<IActionResult> AddToCart(int id)
        {
            // Redirect to login page if user is not logged-in
            var movie = await _movieLibraryService.GetSingleMovieAsync(id);
            var cartId = _shoppingCartService.GetCartId(this.HttpContext);

            var result = await _shoppingCartService.AddItemToCart(movie, cartId);
            
            return RedirectToAction("Index");
        }

        // GET: /ShoppingCart/RemoveFromCart/5
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var movie = await _movieLibraryService.GetSingleMovieAsync(id);
            var cartId = _shoppingCartService.GetCartId(this.HttpContext);

            var result = await _shoppingCartService.RemoveItemToCart(movie, cartId);

            return RedirectToAction("Index");
        }

        // GET: /ShoppingCart/ClearCart
        public async Task<IActionResult> ClearCart()
        {
            var cartId = _shoppingCartService.GetCartId(this.HttpContext);
            await _shoppingCartService.ClearCartAsync(cartId);

            return RedirectToAction("Index");            
        }
    }
}