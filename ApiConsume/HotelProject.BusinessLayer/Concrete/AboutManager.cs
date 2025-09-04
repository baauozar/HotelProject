using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void TDelete(About t)
        {
           
            aboutDal.Delete(t);

        }

        public About TGetByID(int id)
        {
         
            return aboutDal.GetByID(id);

        }

        public List<About> TGetList()
        {
            return aboutDal.GetList();
            
        }

        public void TInsert(About t)
        {
           
            aboutDal.Insert(t);

        }

        public void TUpdate(About t)
        {
        
            aboutDal.Update(t);

        }
    }
}
