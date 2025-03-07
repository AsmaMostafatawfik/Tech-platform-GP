using GP.Business.Services;
using Microsoft.AspNetCore.Mvc;
using GP.Data.Entities;
using System.Threading.Tasks;


namespace Ecommerce_GP.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index(int productId)
        {
            if (productId == 0)
            {
                return NotFound();
            }
            List<Review> reviews = _reviewService.GetReviewsByProductId(productId);
            return View(reviews);
        }

        public IActionResult Details(int id)
        {
            var review = _reviewService.GetReviewById(id);
            if (review == null)
                return NotFound();
            return View(review);
        }

        public IActionResult AddReview(int productId)
        {
            var review = new Review { ProductID = productId, CreateDate = DateTime.Now };
            return View(review);
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _reviewService.AddReview(review);
                if (isAdded)
                    return RedirectToAction("Details", "Product", new { id = review.ProductID });
            }
            return View(review);
        }





    }
}
