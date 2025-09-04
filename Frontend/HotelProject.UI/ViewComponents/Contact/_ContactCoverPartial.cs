using Microsoft.AspNetCore.Mvc;

namespace HotelProject.UI.ViewComponents.Contact
{
    public class _ContactCoverPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
