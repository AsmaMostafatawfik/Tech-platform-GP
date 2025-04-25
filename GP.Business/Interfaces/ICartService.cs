using GP.Data.Entities;
<<<<<<< HEAD

public interface ICartService
{
    Task<List<ShoppingCart>> GetCartItemsAsync(string userId);
    Task AddToCartAsync(string userId, int productId);
    Task RemoveFromCartAsync(string userId, int productId);
    Task IncreaseQuantityAsync(string userId, int productId);
    Task DecreaseQuantityAsync(string userId, int productId);
    Task ClearCartAsync(string userId);
    Task<decimal> GetTotalAmountAsync(string userId); // Get the total price
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface ICartService
    {
        Task<List<ShoppingCart>> GetCartItemsAsync(string userId);
        Task AddToCartAsync(string userId, int productId);
        Task RemoveFromCartAsync(string userId, int productId);
    }
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
}
