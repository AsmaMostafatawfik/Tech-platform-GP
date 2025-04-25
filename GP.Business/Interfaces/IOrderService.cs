using GP.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(string userId, CheckoutRequest request, string sessionId = null);
        Task<OrderResponse> GetOrderDetailsAsync(int orderId);
        Task<List<OrderResponse>> GetUserOrdersAsync(string userId);
        Task CancelOrderAsync(int orderId);
        Task ConfirmOrderAsync(int orderId);
        Task UpdateOrderStatusAsync(int orderId, UpdateOrderStatusRequest request);
    }
}






//using GP.Data.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace GP.Services
//{
//    public interface IOrderService
//    {
//       Task<IEnumerable<Order>> GetAllOrdersAsync();
//        Task<Order?> GetOrderByIdAsync(int orderId);
//        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
//        Task<Order> PlaceOrderAsync(string userId);
//        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
//        Task<bool> CancelOrderAsync(int orderId);
//        Task<bool> DeleteOrderAsync(int orderId);
//    }
//}
