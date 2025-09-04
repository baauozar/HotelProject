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
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactdal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactdal = contactDal;
        }

        public void TDelete(Contact t)
        {
            contactdal.Delete(t);

        }

        public Contact TGetByID(int id)
        {
            return contactdal.GetByID(id);
        }

        public int TGetContactCount()
        {
            return contactdal.GetContactCount();
        }

        public List<Contact> TGetList()
        {
            return contactdal.GetList();
        }

        public void TInsert(Contact t)
        {
            contactdal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            contactdal.Update(t);
        }
    }
}