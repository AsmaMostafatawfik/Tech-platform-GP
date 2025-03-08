using GP.Data.Entities;
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
}
