using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GP.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "User Name")]
        public string? FullName { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();



    }
}
