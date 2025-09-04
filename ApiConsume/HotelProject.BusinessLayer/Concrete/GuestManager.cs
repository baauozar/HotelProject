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
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal  guestDal;

        public GuestManager(IGuestDal guestDal)
        {
            this.guestDal = guestDal;
        }

        public void TDelete(Guest t)
        {
            guestDal.Delete(t);
        }

        public Guest TGetByID(int id)
        {
            return guestDal.GetByID(id);
        }

        public List<Guest> TGetList()
        {
            return guestDal.GetList();
        }

        public void TInsert(Guest t)
        {
            guestDal.Insert(t);
        }

        public void TUpdate(Guest t)
        {
            guestDal.Update(t);
        }
    }
}
