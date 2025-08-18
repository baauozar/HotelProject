using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _RoomPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
