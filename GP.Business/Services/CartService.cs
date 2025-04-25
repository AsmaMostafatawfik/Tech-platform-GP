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

<<<<<<< HEAD
        // Get all cart items for the user
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        public async Task<List<ShoppingCart>> GetCartItemsAsync(string userId)
        {
            return await _db.ShoppingCarts
                            .Include(c => c.Product)
                            .Where(c => c.UserID == userId)
                            .ToListAsync();
        }

<<<<<<< HEAD
        // Add an item to the cart
        public async Task AddToCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts
                .FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);

            if (existingItem != null)
            {
                existingItem.Quantity += 1; // Increase quantity if the item already exists
=======
        public async Task AddToCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);
            if (existingItem != null)
            {
                existingItem.Quantity += 1;
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
            }
            else
            {
                var newItem = new ShoppingCart
                {
                    Quantity = 1,
                    ProductID = productId,
                    UserID = userId
                };
<<<<<<< HEAD
                _db.ShoppingCarts.Add(newItem); // Add the new item to the cart
            }

            await _db.SaveChangesAsync();
        }

        // Remove an item from the cart
        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts
                .FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);

=======
                _db.ShoppingCarts.Add(newItem);
            }
            await _db.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
<<<<<<< HEAD
                    existingItem.Quantity -= 1; // Decrease quantity if more than 1
                }
                else
                {
                    _db.ShoppingCarts.Remove(existingItem); // Remove the item if quantity is 1
=======
                    existingItem.Quantity -= 1;
                }
                else
                {
                    _db.ShoppingCarts.Remove(existingItem);
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
                }
                await _db.SaveChangesAsync();
            }
        }
<<<<<<< HEAD

        // Increase quantity of item in the cart
        public async Task IncreaseQuantityAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts
                .FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);

            if (existingItem != null)
            {
                existingItem.Quantity += 1; // Increase the quantity
                await _db.SaveChangesAsync();
            }
        }

        // Decrease quantity of item in the cart
        public async Task DecreaseQuantityAsync(string userId, int productId)
        {
            var existingItem = await _db.ShoppingCarts
                .FirstOrDefaultAsync(c => c.ProductID == productId && c.UserID == userId);

            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1; // Decrease quantity if more than 1
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.ShoppingCarts.Remove(existingItem); // Remove item if quantity becomes 0
                    await _db.SaveChangesAsync();
                }
            }
        }

        // Clear all items from the cart
        public async Task ClearCartAsync(string userId)
        {
            var cartItems = _db.ShoppingCarts.Where(u => u.UserID == userId).ToList();
            _db.ShoppingCarts.RemoveRange(cartItems);
            await _db.SaveChangesAsync();
        }

        // Get total price of items in the cart
        public async Task<decimal> GetTotalAmountAsync(string userId)
        {
            var cartItems = await _db.ShoppingCarts
                .Include(c => c.Product)
                .Where(c => c.UserID == userId)
                .ToListAsync();

            decimal totalAmount = 0;

            foreach (var item in cartItems)
            {
                totalAmount += item.Quantity * item.Product.Price; // Calculate the total price for each item
            }

            return totalAmount;
        }
    }

}
=======
    }
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
