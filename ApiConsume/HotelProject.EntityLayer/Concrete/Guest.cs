using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string? GuestName { get; set; }
        public string? GuestSurname { get; set; }
        public string? GuestCity { get; set; }
    }
}
