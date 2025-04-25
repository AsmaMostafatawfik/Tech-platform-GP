using GP.Business.Interfaces;
using GP.Data.DTOs;
using GP.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce_GP.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(
            IOrderService orderService,
            ICartService cartService,
            UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _userManager = userManager;
        }

        // GET: /orders/checkout
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        // POST: /orders/checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutRequest request)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var order = await _orderService.CreateOrderAsync(userId, request);
                TempData["SuccessMessage"] = "Order placed successfully!";
                return RedirectToAction("Details", new { orderId = order.OrderID });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(request);
            }
        }

        // POST: /orders/create-checkout-session
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckoutSession(decimal amount)
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetCartItemsAsync(userId);

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Cart is empty.";
                return RedirectToAction("Index", "Cart");
            }

            var domain = $"{Request.Scheme}://{Request.Host}";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmount = (long)(amount * 100),
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Ecommerce Order"
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/Order/PaymentSuccess?sessionId={CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/Cart/Index",
                Metadata = new Dictionary<string, string>
                {
                    { "UserId", userId }
                }
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            // Store session ID temporarily (optional, for validation)
            TempData["CheckoutSessionId"] = session.Id;

            return Redirect(session.Url);
        }

        // GET: /orders/payment-success
        [HttpGet]
        public async Task<IActionResult> PaymentSuccess(string sessionId)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var sessionService = new SessionService();
                var session = await sessionService.GetAsync(sessionId);

                if (session.PaymentStatus == "paid" && session.Metadata["UserId"] == userId)
                {
                    var checkoutRequest = new CheckoutRequest
                    {
                        // Dummy payment details since Stripe handles the payment
                        CardNumber = "N/A",
                        ExpMonth = "N/A",
                        ExpYear = "N/A",
                        Cvc = "N/A",
                        ShippingAddress = "Provided via Stripe" // Update if capturing address
                    };

                    var order = await _orderService.CreateOrderAsync(userId, checkoutRequest, sessionId);
                    TempData["SuccessMessage"] = "Payment and order processed successfully!";
                    return RedirectToAction("Details", new { orderId = order.OrderID });
                }

                TempData["ErrorMessage"] = "Payment verification failed.";
                //return RedirectToAction("Index", "Cart");
                return View("~/Views/PaymentTransaction/Success.cshtml");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error processing payment: {ex.Message}";
                return RedirectToAction("Index", "Cart");
            }
        }

        // GET: /orders/{orderId}
        [HttpGet]
        public async Task<IActionResult> Details(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderDetailsAsync(orderId);
                return View(order);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("UserOrders");
            }
        }

        // GET: /orders/user
        [HttpGet]
        public async Task<IActionResult> UserOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _orderService.GetUserOrdersAsync(userId);
            return View(orders);
        }

        // POST: /orders/{orderId}/cancel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int orderId)
        {
            try
            {
                await _orderService.CancelOrderAsync(orderId);
                TempData["SuccessMessage"] = "Order canceled successfully!";
                return RedirectToAction("UserOrders");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", new { orderId });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int orderId)
        {
            try
            {
                await _orderService.ConfirmOrderAsync(orderId);
                TempData["SuccessMessage"] = "Order confirmed successfully!";
                return RedirectToAction("Details", new { orderId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", new { orderId });
            }
        }





        // POST: /orders/{orderId}/status
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int orderId, UpdateOrderStatusRequest request)
        {
            try
            {
                await _orderService.UpdateOrderStatusAsync(orderId, request);
                TempData["SuccessMessage"] = "Order status updated successfully!";
                return RedirectToAction("Details", new { orderId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", new { orderId });
            }
        }
    }
}













//using GP.Data.Entities;
//using GP.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace GP.Web.Controllers
//{
//    [Authorize]
//    public class OrderController : Controller
//    {
//        private readonly IOrderService _orderService;

//        public OrderController(IOrderService orderService)
//        {
//            _orderService = orderService;
//        }



















//        //[Authorize(Roles = "Admin")]
//        //public async Task<IActionResult> ManageOrders()
//        //{
//        //    var orders = await _orderService.GetAllOrdersAsync();
//        //    return View(orders);
//        //}

//        //public async Task<IActionResult> MyOrders()
//        //{
//        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        //    var orders = await _orderService.GetOrdersByUserIdAsync(userId);
//        //    return View(orders);
//        //}

//        //public async Task<IActionResult> OrderDetails(int orderId)
//        //{
//        //    var order = await _orderService.GetOrderByIdAsync(orderId);
//        //    if (order == null) return NotFound();
//        //    return View(order);
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> PlaceOrder()
//        //{
//        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//        //    try
//        //    {
//        //        var order = await _orderService.PlaceOrderAsync(userId);
//        //        return RedirectToAction("OrderDetails", new { orderId = order.OrderID });
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return BadRequest(ex.Message);
//        //    }
//        //}

//        //[Authorize(Roles = "Admin")]
//        //[HttpPost]
//        //public async Task<IActionResult> UpdateStatus(int orderId, string status)
//        //{
//        //    var result = await _orderService.UpdateOrderStatusAsync(orderId, status);
//        //    return result ? RedirectToAction("ManageOrders") : BadRequest("Failed to update status.");
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CancelOrder(int orderId)
//        //{
//        //    var result = await _orderService.CancelOrderAsync(orderId);
//        //    return result ? RedirectToAction("MyOrders") : BadRequest("Cannot cancel this order.");
//        //}

//        //[Authorize(Roles = "Admin")]
//        //[HttpPost]
//        //public async Task<IActionResult> DeleteOrder(int orderId)
//        //{
//        //    var result = await _orderService.DeleteOrderAsync(orderId);
//        //    return result ? RedirectToAction("ManageOrders") : BadRequest("Failed to delete order.");
//        //}
//    }
//}
