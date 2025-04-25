<<<<<<< HEAD
﻿//using System.Collections.Generic;
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
=======
﻿using GP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        IEnumerable<Order>GetOrdersByUserId(string userId);
    }
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
