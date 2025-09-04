using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Dashboard
{
    public class _DashboardScriptPartial : ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}