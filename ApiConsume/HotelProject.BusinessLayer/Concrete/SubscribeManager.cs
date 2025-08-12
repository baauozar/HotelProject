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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal servicesDal;

        public SubscribeManager(ISubscribeDal servicesDal)
        {
            this.servicesDal = servicesDal;
        }
        public void TDelete(Subscribe t)
        {
            servicesDal.Delete(t);
        }

        public Subscribe TGetByID(int id)
        {
            return servicesDal.GetByID(id);
        }

        public List<Subscribe> TGetList()
        {
            return servicesDal.GetList();
        }

        public void TInsert(Subscribe t)
        {
            servicesDal.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            servicesDal.Update(t);  
        }
    }
}
