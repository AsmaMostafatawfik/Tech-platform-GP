using GP.Business.Interfaces;
using GP.Data.Data;
using GP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _db;

        public CartService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ShoppingCart>> GetCartItemsAsync(string userId)
        {
            return await _db.ShoppingCarts
                            .Include(c => c.Product)
                            .Where(c => c.UserID == userId)
                            .ToListAsync();
        }

        public async Task AddToCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                var newItem = new ShoppingCart
                {
                    Quantity = 1,
                    ProductID = productId,
                    UserID = userId
                };
                _db.ShoppingCarts.Add(newItem);
            }
            await _db.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1;
                }
                else
                {
                    _db.ShoppingCarts.Remove(existingItem);
                }
                await _db.SaveChangesAsync();
            }
        }
    }
}
