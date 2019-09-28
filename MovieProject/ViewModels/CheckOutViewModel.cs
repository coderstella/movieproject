using movieproject.Models;
using movieproject.Views.Movies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class CheckOutViewModel
    {
        public Order Order { get; set; }
        public string ShoppingCartId { get; set; }

        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        public string CurrentUserId { get; set; }
        public decimal OrderItemsTotal { get; set; }
    }
}
