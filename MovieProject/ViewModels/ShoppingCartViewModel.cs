using movieproject.Models;
using movieproject.Views.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItem> CartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
