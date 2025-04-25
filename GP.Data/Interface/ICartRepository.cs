using GP.Data.Entities;
<<<<<<< HEAD
using GP.Data.Interface;
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
<<<<<<< HEAD
    public interface ICartRepository : IGenericRepository<ShoppingCart>
=======
    public interface ICartRepository:IGenericRepository<ShoppingCart>
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
    {
        IEnumerable<ShoppingCart> GetCartItemsByUser(string userId);
        void ClearCart(string userId);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
