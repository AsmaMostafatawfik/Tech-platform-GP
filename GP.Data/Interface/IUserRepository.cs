using GP.Data.Entities;
<<<<<<< HEAD
using GP.Data.Interface;
=======
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Repositories
{
<<<<<<< HEAD
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetUserByEmail(string Email);
    }
}
=======
    public interface IUserRepository:IGenericRepository <ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetUserByEmail(string Email);
    }
}
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
