using Microsoft.AspNetCore.Identity;
using movieproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [DisplayName("Order Date")]
        public DateTime OrderPlaced { get; set; }

        public string ShoppingCartId { get; set; }


        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public int ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }


    }
}
