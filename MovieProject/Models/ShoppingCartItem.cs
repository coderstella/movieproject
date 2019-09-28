using movieproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Views.Movies
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public string ShoppingCartId { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        // Foreign key
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
