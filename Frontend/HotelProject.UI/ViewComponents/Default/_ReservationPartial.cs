using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _ReservationPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
  
}
