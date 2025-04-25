
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
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        }

<<<<<<< HEAD
        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model, string role = "Customer")
=======
        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model,string role="Customer")
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = model.Name,
                Email = model.Email,
                UserName = model.Email
            };
<<<<<<< HEAD
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(role))
=======
            var result= await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync(role))
>>>>>>> 88f5b6972038202f1d1b220064a20758c3447c07
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);
            }
            return result;
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