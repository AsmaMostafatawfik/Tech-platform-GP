using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser? User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public int PaymentTransactionID { get; set; }
        [ForeignKey("PaymentTransactionID")]
        public virtual PaymentTransaction? PaymentTransaction { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public string? ShippingAddress { get; set; } // New field for shipping address



    }
}
