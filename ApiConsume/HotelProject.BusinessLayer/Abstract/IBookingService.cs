using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService: IGenericService<Booking>
    {
       
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeDecline(int id);
        void TBookingStatusChangeWaiting(int id);
        int TGetBookingCount();
        List<Booking> TGetLast6Bookings();

    }
}
