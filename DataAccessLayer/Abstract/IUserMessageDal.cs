using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserMessageDal : IGenericDal<UserMessage>
    {
        //kullanici mesajlarini kullanicilar ile birlikte getirmek icin kodladik
        public List<UserMessage> GetUserMessagesWithUser();
    }
}
