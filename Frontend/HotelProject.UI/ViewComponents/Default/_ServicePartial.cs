using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _ServicePartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }   
    
}
