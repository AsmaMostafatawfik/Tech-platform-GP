using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.DTOs
{
    public class CheckoutRequest
    {
        public string CardNumber { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public string Cvc { get; set; }
        public string ShippingAddress { get; set; }
    }

    public class OrderResponse
    {
        public int OrderID { get; set; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }

    public class OrderDetailResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateOrderStatusRequest
    {
        public string Status { get; set; } // e.g., "Pending", "Shipped", "Delivered", "Canceled"
    }



}
