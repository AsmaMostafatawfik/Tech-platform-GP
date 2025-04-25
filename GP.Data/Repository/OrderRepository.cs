using GP.Data.Data;
using GP.Data.Entities;
using GP.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            return _context.Orders.Where(o=>o.UserID == userId).ToList();
        }

    }
}
