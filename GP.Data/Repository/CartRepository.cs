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
    public class CartRepository : GenericRepository<ShoppingCart>, ICartRepository
    {

        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void ClearCart(string userId)
        {
            var CartItems=_context.ShoppingCarts.Where(u=>u.UserID == userId).ToList();
            _dbSet.RemoveRange(CartItems);
            _context.SaveChanges();
        }

        public IEnumerable<ShoppingCart> GetCartItemsByUser(string userId)
        {
            return _context.ShoppingCarts
                   .Where(c => c.UserID == userId)
                   .Include(c => c.Product) 
                   .ToList();
        }
    }
}
