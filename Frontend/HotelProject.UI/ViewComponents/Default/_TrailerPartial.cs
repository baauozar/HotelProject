using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _TrailerPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }   
    
}
