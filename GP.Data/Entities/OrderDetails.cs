using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.Data.Entities
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order? Order { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }


    }
}
