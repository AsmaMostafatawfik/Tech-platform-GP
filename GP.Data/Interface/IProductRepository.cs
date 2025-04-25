using GP.Data.Entities;
using GP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Interface
{
<<<<<<< HEAD
    public interface IProductRepository : IGenericRepository<Product>
=======
    public interface IProductRepository: IGenericRepository<Product>
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
<<<<<<< HEAD

    }
}
=======
        
    }
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
