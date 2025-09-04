using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            this.bookingDal = bookingDal;
        }

 

        public void TBookingStatusChangeApproved(int id)
        {
            bookingDal.BookingStatusChangeApproved(id);
        }

        public void TBookingStatusChangeDecline(int id)
        {
            bookingDal.BookingStatusChangeDecline(id);
        }

        public void TBookingStatusChangeWaiting(int id)
        {
            bookingDal.BookingStatusChangeWaiting(id);
        }

        public void TDelete(Booking t)
        {
            bookingDal.Delete(t);
        }

        public int TGetBookingCount()
        {
           return bookingDal.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
            return bookingDal.GetByID(id);
        }

        public List<Booking> TGetLast6Bookings()
        {
            return bookingDal.GetLast6Bookings();

        }

        public List<Booking> TGetList()
        {
            return bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
             bookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            bookingDal.Update(t);
        }
    }
}
