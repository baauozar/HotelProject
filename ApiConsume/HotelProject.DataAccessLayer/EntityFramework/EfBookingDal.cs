using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GnericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;
        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

   

        public void BookingStatusChangeApproved(int id)
        {

            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "Approved";
                _context.SaveChanges();
            }
        }

        public void BookingStatusChangeDecline(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "Cancel";
                _context.SaveChanges();
            }
        }

        public void BookingStatusChangeWaiting(int id)
        {
            var value = _context.Bookings.Find(id);
            if (value != null)
            {
                value.Status = "On hold";
                _context.SaveChanges();
            }
        }

        public int GetBookingCount()
        {
            var values = _context.Bookings.Count();
            return values;
        }

        public List<Booking> GetLast6Bookings()
        {
            var value= _context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return value;
        }
    }
}
