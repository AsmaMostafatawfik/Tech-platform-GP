
using System.Threading.Tasks;
using GP.Business.Interfaces;
using GP.Data.Entities;
using GP.Data;
using GP.Data.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace GP.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = model.Name,
                Email = model.Email,
                UserName = model.Email
            };
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (removePasswordResult.Succeeded)
                {
                    return await _userManager.AddPasswordAsync(user, model.NewPassword);
                }
                return removePasswordResult;
            }
            return IdentityResult.Failed(new IdentityError { Description = "User not found" });
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    
    }
}
