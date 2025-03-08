using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Business.Interfaces;
using GP.Data.Data;
using GP.Data.Entities;
using GP.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace GP.Business.Services
{

        public class ProductService : IProductService
        {
            private readonly IProductRepository _productRepository;

            public ProductService(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IEnumerable<Product>> GetAllProductsAsync()
            {
                return await _productRepository.GetAllProductsAsync();
            }

            public async Task<Product> GetProductByIdAsync(int id)
            {
                return await _productRepository.GetProductByIdAsync(id);
            }

            public async Task AddProductAsync(Product product)
            {
                product.CreateDate = DateTime.Now;
                await _productRepository.AddProductAsync(product);
            }

            public async Task UpdateProductAsync(Product product)
            {
                await _productRepository.UpdateProductAsync(product);
            }

            public async Task DeleteProductAsync(int id)
            {
                await _productRepository.DeleteProductAsync(id);
            }
        }

    }

