using Microsoft.AspNetCore.Mvc;
using GP.Business;
using GP.Data;
using GP.Business.Services;
using GP.Data.Entities;
using GP.Business.Interfaces;

namespace GP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _adminService.GetAllUsersAsync();
            return View(users);
        }
        public async Task<IActionResult> UserDetails(int id)
        {
            var user = await _adminService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(ApplicationUser User)
        {
            if (ModelState.IsValid)
            {
                return View(User);
            }
            await _adminService.AddUserAsync(User);
            return RedirectToAction(nameof(Users));
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _adminService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _adminService.UpdateUserAsync(user);
                return RedirectToAction(nameof(Users));
            }
            return View(user);
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _adminService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Products()
        {
            var products = await _adminService.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _adminService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddProductAsync(product);
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _adminService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _adminService.UpdateProductAsync(product);
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _adminService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Products));
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _adminService.GetAllOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await _adminService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _adminService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Orders));
        }

        public async Task<IActionResult> Reviews()
        {
            var reviews = await _adminService.GetAllReviewsAsync();
            return View(reviews);
        }

        public async Task<IActionResult> DeleteReview(int id)
        {
            await _adminService.DeleteReviewAsync(id);
            return RedirectToAction(nameof(Reviews));
        }
    }
}