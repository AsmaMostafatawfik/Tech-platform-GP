using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_GP.Controllers
{
    public class PaymentTransactionController : Controller
    {
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisaPayment()
        {
            return View();
        }
    }
}
