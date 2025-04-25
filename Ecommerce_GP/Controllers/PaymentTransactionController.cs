using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using GP.Business.Services;
=======
using GP.Business.Services;  
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using GP.Business.Interfaces;
using Stripe.Checkout;

namespace Ecommerce_GP.Controllers
{
    [Authorize]
    public class PaymentTransactionController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentTransactionController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(
            string cardNumber,
            string expMonth,
            string expYear,
            string cvc,
            decimal amount)
        {
            try
            {
                var result = await _paymentService.ProcessPayment(
                    cardNumber,
                    expMonth,
                    expYear,
                    cvc,
                    amount,
                    "usd");

                if (result.Status == "succeeded")
                {
                    TempData["SuccessMessage"] = "Payment processed successfully!";
                    return RedirectToAction("Success");
                }
                else
                {
                    TempData["ErrorMessage"] = $"Payment failed: {result.FailureMessage}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckoutSession(decimal amount)
        {
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
                        Name = "Ecommerce Payment"
                    },
                },
                Quantity = 1,
            },
        },
                Mode = "payment",
                SuccessUrl = domain + "/PaymentTransaction/Success",
                CancelUrl = domain + "/PaymentTransaction/Index",
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return Redirect(session.Url);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}