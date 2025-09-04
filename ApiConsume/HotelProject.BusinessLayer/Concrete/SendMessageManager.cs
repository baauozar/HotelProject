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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal messageDal;

        public SendMessageManager(ISendMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void TDelete(SendMessage t)
        {
            messageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
           return messageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
           return messageDal.GetList();
        }

        public int TGetSendMessageCount()
        {
            return messageDal.GetSendMessageCount();

        }

        public void TInsert(SendMessage t)
        {
            messageDal.Insert(t);   
        }

        public void TUpdate(SendMessage t)
        {
            messageDal.Update(t);   
        }
    }
}
