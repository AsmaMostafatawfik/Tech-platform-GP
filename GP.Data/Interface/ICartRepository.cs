using GP.Data.Entities;
using GP.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public interface ICartRepository : IGenericRepository<ShoppingCart>
    {
        IEnumerable<ShoppingCart> GetCartItemsByUser(string userId);
        void ClearCart(string userId);
    }
}