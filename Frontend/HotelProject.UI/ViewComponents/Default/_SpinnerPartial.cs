using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _SpinnerPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
