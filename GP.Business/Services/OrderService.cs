using GP.Business.Interfaces;
using GP.Data.Data;
using GP.Data.DTOs;
using GP.Data.Entities;
using GP.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly ApplicationDbContext _db;

        public OrderService(
            IOrderRepository orderRepository,
            ICartService cartService,
            IPaymentService paymentService,
            ApplicationDbContext db)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _paymentService = paymentService;
            _db = db;
        }

        public async Task<OrderResponse> CreateOrderAsync(string userId, CheckoutRequest request, string sessionId = null)
        {
            // Validate cart
            var cartItems = await _cartService.GetCartItemsAsync(userId);
            if (!cartItems.Any())
                throw new Exception("Cart is empty.");

            // Calculate total amount
            decimal totalAmount = await _cartService.GetTotalAmountAsync(userId);

            // Create payment transaction
            var paymentTransaction = new PaymentTransaction
            {
                Amount = totalAmount,
                PaymentMethod = PaymentMethod.Visa, // Adjust based on Stripe data if needed
                Status = "Completed",
                TransactionDate = DateTime.UtcNow,
                StripeSessionId = sessionId // Store Stripe session ID for reference
            };
            _db.PaymentTransactions.Add(paymentTransaction);
            await _db.SaveChangesAsync();

            // Create order
            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = (int)totalAmount,
                Status = "Pending",
                PaymentTransactionID = paymentTransaction.TransactionID,
                ShippingAddress = request.ShippingAddress
            };

            // Add order details
            order.OrderDetails = cartItems.Select(item => new OrderDetails
            {
                ProductID = item.ProductID,
                Quantity = item.Quantity,
                Price = item.Product.Price
            }).ToList();

            // Save order
            var createdOrder = await _orderRepository.CreateOrderAsync(order);

            // Clear cart
            await _cartService.ClearCartAsync(userId);

            // Map to response
            return MapToOrderResponse(createdOrder);
        }

        public async Task<OrderResponse> GetOrderDetailsAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found.");
            return MapToOrderResponse(order);
        }

        public async Task<List<OrderResponse>> GetUserOrdersAsync(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return orders.Select(MapToOrderResponse).ToList();
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found.");
            if (order.Status != "Pending")
                throw new Exception("Order cannot be canceled as it has already been processed.");

            order.Status = "Canceled";
            await _orderRepository.UpdateOrderAsync(order);
        }


        public async Task ConfirmOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found.");
            if (order.Status != "Pending")
                throw new Exception("Order cannot be confirmed as it is not in a pending state.");

            order.Status = "Confirmed";
            await _orderRepository.UpdateOrderAsync(order);
        }










        public async Task UpdateOrderStatusAsync(int orderId, UpdateOrderStatusRequest request)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found.");

            order.Status = request.Status;
            await _orderRepository.UpdateOrderAsync(order);
        }

        private OrderResponse MapToOrderResponse(Order order)
        {
            return new OrderResponse
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailResponse
                {
                    ProductID = od.ProductID,
                    ProductName = od.Product?.Name,
                    Quantity = od.Quantity,
                    Price = od.Price
                }).ToList()
            };
        }
    }
}








//using GP.Data.Entities;
//using GP.Data.Interface;
//using GP.Data.Repositories;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GP.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IOrderRepository _orderRepository;

//        public OrderService(IOrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }






//        //public async Task<IEnumerable<Order>> GetAllOrdersAsync()
//        //{
//        //    return await _orderRepository.GetAllAsync();
//        //}

//        //public async Task<Order?> GetOrderByIdAsync(int orderId)
//        //{
//        //    return await _orderRepository.GetByIdAsync(orderId);
//        //}

//        //public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
//        //{
//        //    return await _orderRepository.GetOrdersByUserIdAsync(userId);
//        //}

//        //public async Task<Order> PlaceOrderAsync(string userId)
//        //{
//        //    var newOrder = new Order
//        //    {
//        //        UserID = userId,
//        //        Status = "Pending",
//        //        OrderDetails = new List<OrderDetails>()
//        //    };

//        //    await _orderRepository.AddAsync(newOrder);
//        //    return newOrder;
//        //}

//        //public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
//        //{
//        //    var order = await _orderRepository.GetByIdAsync(orderId);
//        //    if (order == null) return false;

//        //    order.Status = status;
//        //    _orderRepository.Update(order);
//        //    await _orderRepository.SaveChangesAsync();
//        //    return true;
//        //}

//        //public async Task<bool> CancelOrderAsync(int orderId)
//        //{
//        //    var order = await _orderRepository.GetByIdAsync(orderId);
//        //    if (order == null || order.Status != "Pending") return false;

//        //    order.Status = "Canceled";
//        //    _orderRepository.Update(order);
//        //    await _orderRepository.SaveChangesAsync();
//        //    return true;
//        //}

//        //public async Task<bool> DeleteOrderAsync(int orderId)
//        //{
//        //    await _orderRepository.DeleteAsync(orderId);
//        //    return true;
//        //}
//    }
//}
