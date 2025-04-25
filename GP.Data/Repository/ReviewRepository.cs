using GP.Data.Data;
using GP.Data.Entities;
using GP.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;


        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetReviewsByProductId(int productId)
        {
            return _dbSet.Where(productid => productid.ProductID == productId).ToList();
        }
    }
}
