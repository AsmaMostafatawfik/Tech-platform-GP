using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GP.Business.Services; // Ensure this service is correctly implemented
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Ecommerce_GP.Controllers
{
    [Authorize]
    public class PaymentTransactionController : Controller
    {
        private readonly PaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public PaymentTransactionController(IConfiguration configuration)
        {
            _configuration = configuration;
            string secretKey = _configuration["Stripe:SecretKey"];
            _paymentService = new PaymentService(secretKey);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string cardNumber, string expMonth, string expYear, string cvc, decimal amount)
        {
            //if (string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(expMonth) || string.IsNullOrWhiteSpace(expYear) || string.IsNullOrWhiteSpace(cvc) || amount <= 0)
            //{
            //    ViewBag.Message = "Invalid payment details. Please try again.";
            //    return View("Failure");
            //}

            var result = await _paymentService.ProcessPayment(cardNumber, expMonth, expYear, cvc, amount, "usd");

            if (result == "succeeded")
            {
                ViewBag.Message = "Payment Successful";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Payment Failed: " + result;
                //return View("Failure");
                return View();
            }
        }
    }
}
