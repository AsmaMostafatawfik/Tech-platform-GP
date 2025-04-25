using GP.Business.Interfaces;
using GP.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_GP.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        // Show Cart
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetCartItemsAsync(userId);
            var totalAmount = await _cartService.GetTotalAmountAsync(userId); // Get total price for cart
            ViewBag.TotalAmount = totalAmount; // Pass total to the view
            return View(cartItems);
        }

        // Add to Cart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddToCartAsync(userId, productId);
            return RedirectToAction("Index");
        }

        // Remove from Cart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.RemoveFromCartAsync(userId, productId);
            return RedirectToAction("Index");
        }

        // Increase Quantity
        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.IncreaseQuantityAsync(userId, productId);
            return RedirectToAction("Index");
        }

        // Decrease Quantity
        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.DecreaseQuantityAsync(userId, productId);
            return RedirectToAction("Index");
        }

        // Clear Cart
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.ClearCartAsync(userId);
            return RedirectToAction("Index");
        }
    }
}