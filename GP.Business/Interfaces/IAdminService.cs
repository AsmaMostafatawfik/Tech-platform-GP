using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data.Entities;

namespace GP.Business.Interfaces
{
    public interface IAdminService
    {
        // User Methods
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task AddUserAsync(ApplicationUser user);
        Task UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(int id);

        // Product Methods
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        // Order Methods
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);

        // Review Methods
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);

        // Cart Methods
        Task<IEnumerable<ShoppingCart>> GetAllCartItemsAsync();
        Task<ShoppingCart> GetCartItemByIdAsync(int id);
        Task AddCartItemAsync(ShoppingCart cartItem);
        Task UpdateCartItemAsync(ShoppingCart cartItem);
        Task DeleteCartItemAsync(int id);

    }
}