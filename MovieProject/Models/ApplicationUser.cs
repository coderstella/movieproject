using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ShippingAddresses = new HashSet<ShippingAddress>();
        }

        [Required]
        public string FullName { get; set; }


        
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
    }
}
