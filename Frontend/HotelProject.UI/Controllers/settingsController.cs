using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.UI.Model.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.Controllers
{
    public class settingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public settingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.Email = values.Email;
            model.Username = values.UserName;


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Name = model.Name;
            values.Surname = model.Surname;
            values.Email = model.Email;
            values.UserName = model.Username;
            if (model.PasswordHash != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.PasswordHash);
            }
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();

        }

    }
}
