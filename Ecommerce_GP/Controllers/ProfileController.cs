using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GP.Business.Services;
using GP.Data.Entities;

namespace Ecommerce_GP.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            var model = new UserProfile
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Image = user.Image
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserProfile model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Image = model.Image;

            await _userManager.UpdateAsync(user);

            ViewBag.Message = "Profile updated successfully.";
            return View(model);
        }
    }
}
