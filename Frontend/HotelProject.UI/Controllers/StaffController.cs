using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
