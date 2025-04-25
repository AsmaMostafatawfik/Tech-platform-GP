//using GP.Data.Data;
//using GP.Data.Entities;
//using GP.Data.Interface;
//using GP.Data.Repository;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GP.Data.Repositories
//{
//    public class OrderRepository : GenericRepository<Order>, IOrderRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public OrderRepository(ApplicationDbContext context) : base(context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId) // ✅ Implemented Correctly
//        {
//            return await _context.Orders
//                .Where(o => o.UserID == userId)
//                .Include(o => o.OrderDetails)
//                .ThenInclude(od => od.Product)
//                .ToListAsync();
//        }
//    }
//}





using GP.Data.Data;
using GP.Data.Entities;
using GP.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Include(o => o.PaymentTransaction)
                .FirstOrDefaultAsync(o => o.OrderID == orderId);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(o => o.UserID == userId)
                .ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ShoppingCart>> GetCartByUserIdAsync(string userId)
        {
            return await _db.ShoppingCarts
                .Include(c => c.Product)
                .Where(c => c.UserID == userId)
                .ToListAsync();
        }

        public async Task ClearCartAsync(string userId)
        {
            var cartItems = await _db.ShoppingCarts
                .Where(c => c.UserID == userId)
                .ToListAsync();
            _db.ShoppingCarts.RemoveRange(cartItems);
            await _db.SaveChangesAsync();
        }
    }
}