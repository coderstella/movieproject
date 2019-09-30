using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieproject.Database;
using movieproject.Models;
using movieproject.Services;
using movieproject.ViewModels;

namespace movieproject.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IOrderService _orderService;

        private readonly IShoppingCartService _shoppingCartService;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userName = HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return Redirect("/Identity/Account/Login?returnUrl=" + Uri.EscapeDataString(HttpContext.Request.Path));
            }

            var cartId = _shoppingCartService.GetCartId(this.HttpContext);
            var currentCartItems = await _shoppingCartService.GetCurrentCart(cartId);
            var currentUser = await _userService.GetCurrentUserAsync(this.HttpContext);

            var viewModel = new CheckOutViewModel
            {
                Order = new Order()
                {
                    User = currentUser,
                    UserId = currentUser.Id,
                    ShippingAddress = new ShippingAddress
                    {
                        User = currentUser,
                        UserId = currentUser.Id
                    }
                },
                ShoppingCartItems = currentCartItems,
                ShoppingCartId = cartId,

                OrderItemsTotal = currentCartItems.Sum(c => c.Movie.Price * c.Quantity)
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CheckoutProcess(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            var currentUser = await _userService.GetCurrentUserAsync(this.HttpContext);
            order.ShippingAddress.User = currentUser;
            order.ShippingAddress.UserId = currentUser.Id;
            order.User = currentUser;
            order.UserId = currentUser.Id;

            await _orderService.CreateOrderAsync(order);

            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = $"Thanks for your order, We'll deliver your movies soon!";
            return View();
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }   
}