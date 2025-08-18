using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    
}
