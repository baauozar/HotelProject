using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _SubscribePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
