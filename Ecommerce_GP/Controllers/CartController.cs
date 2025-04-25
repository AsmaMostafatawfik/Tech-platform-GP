using GP.Business.Interfaces;
using GP.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_GP.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "Customer")]
=======
    [Authorize (Roles ="Customer")]
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

<<<<<<< HEAD
        // Show Cart
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetCartItemsAsync(userId);
<<<<<<< HEAD
            var totalAmount = await _cartService.GetTotalAmountAsync(userId); // Get total price for cart
            ViewBag.TotalAmount = totalAmount; // Pass total to the view
            return View(cartItems);
        }

        // Add to Cart
=======
            return View(cartItems);
        }

>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddToCartAsync(userId, productId);
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        // Remove from Cart
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.RemoveFromCartAsync(userId, productId);
            return RedirectToAction("Index");
<<<<<<< HEAD
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
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        }
    }
}