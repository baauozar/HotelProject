using HotelProject.UI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.UI.Model.Contact
{
    public class ContactFormViewModel
    {
        public CreateContactDto? Contact { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
