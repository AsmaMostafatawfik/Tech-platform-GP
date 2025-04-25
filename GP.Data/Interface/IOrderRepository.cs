//using System.Collections.Generic;
//using System.Threading.Tasks;
//using GP.Data.Entities;

//namespace GP.Data.Repositories
//{
//    public interface IOrderRepository : IGenericRepository<Order>
//    {
//        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId); // ✅ Use async Task<IEnumerable<Order>>
//    }
//}





using GP.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GP.Data.Interface
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task UpdateOrderAsync(Order order);
        Task<List<ShoppingCart>> GetCartByUserIdAsync(string userId);
        Task ClearCartAsync(string userId);
    }
}