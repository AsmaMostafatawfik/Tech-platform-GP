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
    public class UserRpository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRpository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetUserByEmail(string email)
        {
            return _dbSet.Where(u => u.Email == email);
        }
    }
}