using GP.Data.Entities;
using GP.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        IEnumerable<Review> GetReviewsByProductId(int productId);
    }
}