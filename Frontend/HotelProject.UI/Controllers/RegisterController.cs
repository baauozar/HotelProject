using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.UI.Dtos.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _appuser;

        public RegisterController(UserManager<AppUser> appuser)
        {
            _appuser = appuser;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appuser= new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.UserName,
                Email = createNewUserDto.Email,
                City = createNewUserDto.City
                
            };
            var result = await _appuser.CreateAsync(appuser, createNewUserDto.Password);
            if (result.Succeeded)
            {
                // Optionally, you can sign in the user or redirect to a confirmation page
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
