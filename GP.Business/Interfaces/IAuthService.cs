using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data.ViewModels;
using GP.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GP.Business.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> LoginAsync(LoginViewModel model);
<<<<<<< HEAD
        Task<IdentityResult> RegisterAsync(RegisterViewModel model, string role = "Customer");
=======
        Task<IdentityResult> RegisterAsync(RegisterViewModel model, string role="Customer");
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model);
        Task LogoutAsync();
    }
}