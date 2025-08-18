using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _AboutPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
