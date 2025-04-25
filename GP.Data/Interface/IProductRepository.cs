using GP.Data.Entities;
using GP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

    }
}