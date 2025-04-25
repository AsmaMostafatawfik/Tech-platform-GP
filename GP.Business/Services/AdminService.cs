<<<<<<< HEAD
﻿//using GP.Business.Interfaces;
//using GP.Data.Entities;
//using GP.Data.Interface;
//using GP.Data.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GP.Business.Services
//{
//    public class AdminService : IAdminService
//    {
//        //private readonly IGenericRepository<AdminService> _genericRepo;
//        private readonly IUserRepository _userRepo;
//        private readonly ICartRepository _cartRepo;
//        private readonly IProductRepository _productRepo;
//        private IOrderRepository _orderRepo;
//        private readonly IReviewRepository _reviewRepo;

//        public AdminService(
//             IUserRepository userRepo,
//            IProductRepository productRepo,
//            IOrderRepository orderRepo,
//            IReviewRepository reviewRepo
//            )
//        {
//            _userRepo = userRepo;
//            _productRepo = productRepo;
//            _orderRepo = orderRepo;
//            _reviewRepo = reviewRepo;
//        }
//        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync() => await _userRepo.GetAllAsync();
//        public async Task<ApplicationUser> GetUserByIdAsync(int id) => await _userRepo.GetByIdAsync(id);
//        public async Task AddUserAsync(ApplicationUser user) { await _userRepo.AddAsync(user); await _userRepo.SaveChangesAsync(); }
//        public async Task UpdateUserAsync(ApplicationUser user) { _userRepo.Update(user); await _userRepo.SaveChangesAsync(); }
//        public async Task DeleteUserAsync(int id) { await _userRepo.DeleteAsync(id); await _userRepo.SaveChangesAsync(); }

//        // ✅ Product Methods
//        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productRepo.GetAllAsync();
//        public async Task<Product> GetProductByIdAsync(int id) => await _productRepo.GetByIdAsync(id);
//        public async Task AddProductAsync(Product product) { await _productRepo.AddAsync(product); await _productRepo.SaveChangesAsync(); }
//        public async Task UpdateProductAsync(Product product) { _productRepo.Update(product); await _productRepo.SaveChangesAsync(); }
//        public async Task DeleteProductAsync(int id) { await _productRepo.DeleteAsync(id); await _productRepo.SaveChangesAsync(); }

//        // ✅ Order Methods
//        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _orderRepo.GetAllAsync();
//        public async Task<Order> GetOrderByIdAsync(int id) => await _orderRepo.GetByIdAsync(id);
//        public async Task AddOrderAsync(Order order) { await _orderRepo.AddAsync(order); await _orderRepo.SaveChangesAsync(); }
//        public async Task UpdateOrderAsync(Order order) { _orderRepo.Update(order); await _orderRepo.SaveChangesAsync(); }
//        public async Task DeleteOrderAsync(int id) { await _orderRepo.DeleteAsync(id); await _orderRepo.SaveChangesAsync(); }

//        // ✅ Review Methods
//        public async Task<IEnumerable<Review>> GetAllReviewsAsync() => await _reviewRepo.GetAllAsync();
//        public async Task<Review> GetReviewByIdAsync(int id) => await _reviewRepo.GetByIdAsync(id);
//        public async Task AddReviewAsync(Review review) { await _reviewRepo.AddAsync(review); await _reviewRepo.SaveChangesAsync(); }
//        public async Task UpdateReviewAsync(Review review) { _reviewRepo.Update(review); await _reviewRepo.SaveChangesAsync(); }
//        public async Task DeleteReviewAsync(int id) { await _reviewRepo.DeleteAsync(id); await _reviewRepo.SaveChangesAsync(); }

//        // ✅ Cart Methods
//        public async Task<IEnumerable<ShoppingCart>> GetAllCartItemsAsync() => await _cartRepo.GetAllAsync();
//        public async Task<ShoppingCart> GetCartItemByIdAsync(int id) => await _cartRepo.GetByIdAsync(id);
//        public async Task AddCartItemAsync(ShoppingCart cartItem) { await _cartRepo.AddAsync(cartItem); await _cartRepo.SaveChangesAsync(); }
//        public async Task UpdateCartItemAsync(ShoppingCart cartItem) { _cartRepo.Update(cartItem); await _cartRepo.SaveChangesAsync(); }
//        public async Task DeleteCartItemAsync(int id) { await _cartRepo.DeleteAsync(id); await _cartRepo.SaveChangesAsync(); }
//    }
//}
=======
﻿using GP.Business.Interfaces;
using GP.Data.Entities;
using GP.Data.Interface;
using GP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class AdminService : IAdminService
    {
        //private readonly IGenericRepository<AdminService> _genericRepo;
        private readonly IUserRepository _userRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        private IOrderRepository _orderRepo;
        private readonly IReviewRepository _reviewRepo;

        public AdminService(
             IUserRepository userRepo,
            IProductRepository productRepo,
            IOrderRepository orderRepo,
            IReviewRepository reviewRepo
            ) 
        { 
              _userRepo = userRepo;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _reviewRepo = reviewRepo;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync() => await _userRepo.GetAllAsync();
        public async Task<ApplicationUser> GetUserByIdAsync(int id) => await _userRepo.GetByIdAsync(id);
        public async Task AddUserAsync(ApplicationUser user) { await _userRepo.AddAsync(user); await _userRepo.SaveChangesAsync(); }
        public async Task UpdateUserAsync(ApplicationUser user) { _userRepo.Update(user); await _userRepo.SaveChangesAsync(); }
        public async Task DeleteUserAsync(int id) { await _userRepo.DeleteAsync(id); await _userRepo.SaveChangesAsync(); }

        // ✅ Product Methods
        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productRepo.GetAllAsync();
        public async Task<Product> GetProductByIdAsync(int id) => await _productRepo.GetByIdAsync(id);
        public async Task AddProductAsync(Product product) { await _productRepo.AddAsync(product); await _productRepo.SaveChangesAsync(); }
        public async Task UpdateProductAsync(Product product) { _productRepo.Update(product); await _productRepo.SaveChangesAsync(); }
        public async Task DeleteProductAsync(int id) { await _productRepo.DeleteAsync(id); await _productRepo.SaveChangesAsync(); }

        // ✅ Order Methods
        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _orderRepo.GetAllAsync();
        public async Task<Order> GetOrderByIdAsync(int id) => await _orderRepo.GetByIdAsync(id);
        public async Task AddOrderAsync(Order order) { await _orderRepo.AddAsync(order); await _orderRepo.SaveChangesAsync(); }
        public async Task UpdateOrderAsync(Order order) { _orderRepo.Update(order); await _orderRepo.SaveChangesAsync(); }
        public async Task DeleteOrderAsync(int id) { await _orderRepo.DeleteAsync(id); await _orderRepo.SaveChangesAsync(); }

        // ✅ Review Methods
        public async Task<IEnumerable<Review>> GetAllReviewsAsync() => await _reviewRepo.GetAllAsync();
        public async Task<Review> GetReviewByIdAsync(int id) => await _reviewRepo.GetByIdAsync(id);
        public async Task AddReviewAsync(Review review) { await _reviewRepo.AddAsync(review); await _reviewRepo.SaveChangesAsync(); }
        public async Task UpdateReviewAsync(Review review) { _reviewRepo.Update(review); await _reviewRepo.SaveChangesAsync(); }
        public async Task DeleteReviewAsync(int id) { await _reviewRepo.DeleteAsync(id); await _reviewRepo.SaveChangesAsync(); }

        // ✅ Cart Methods
        public async Task<IEnumerable<ShoppingCart>> GetAllCartItemsAsync() => await _cartRepo.GetAllAsync();
        public async Task<ShoppingCart> GetCartItemByIdAsync(int id) => await _cartRepo.GetByIdAsync(id);
        public async Task AddCartItemAsync(ShoppingCart cartItem) { await _cartRepo.AddAsync(cartItem); await _cartRepo.SaveChangesAsync(); }
        public async Task UpdateCartItemAsync(ShoppingCart cartItem) { _cartRepo.Update(cartItem); await _cartRepo.SaveChangesAsync(); }
        public async Task DeleteCartItemAsync(int id) { await _cartRepo.DeleteAsync(id); await _cartRepo.SaveChangesAsync(); }
    }
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
