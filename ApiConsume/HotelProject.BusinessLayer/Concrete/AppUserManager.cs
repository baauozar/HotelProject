using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public int TAppuserCount()
        {
            return _appUserDal.AppuserCount();
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);

        }

        public AppUser TGetByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetList();
        }

        public List<AppUser> TGetUserWithWorkLocation()
        {
            return _appUserDal.GetUserWithWorkLocation();
        }

        public void TInsert(AppUser t)
        {
           _appUserDal.Insert(t);
        }

        public void TUpdate(AppUser t)
        {
           _appUserDal.Update(t);
        }

        public List<AppUser> TUsersListWithWorkLocation()
        {
            return _appUserDal.UsersListWithWorkLocation();
        }
    }
}
