using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GP.Data.Entities
{
    public enum PaymentMethod { Cash, Visa }

    public class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public int OrderID { get; set; }
        [InverseProperty("PaymentTransaction")]
        public virtual Order? Order { get; set; }

        public string? StripeSessionId { get; set; }
    }
}
