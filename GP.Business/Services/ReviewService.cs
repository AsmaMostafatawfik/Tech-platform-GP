using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data.Data;
using GP.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GP.Business.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByProductId(int productId)
        {
            return _context.Reviews
                      .Where(r => r.ProductID == productId)
                      .ToList();
        }

        public Review? GetReviewById(int id)
        {
            return _context.Reviews.Find(id);
        }

        public bool AddReview(Review review)
        {
            _context.Reviews.Add(review);
            return _context.SaveChanges() > 0;  
        }








    }
}
