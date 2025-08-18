using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}

