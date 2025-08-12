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
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            this.servicesDal = servicesDal;
        }
        public void TDelete(Service t)
        {
            servicesDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return servicesDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return servicesDal.GetList();
        }

        public void TInsert(Service t)
        {
            servicesDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            servicesDal.Update(t);
        }
    }
}
