using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _TeamPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
  
}
