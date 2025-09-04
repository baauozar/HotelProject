using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.Controllers
{
    public class MessageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
