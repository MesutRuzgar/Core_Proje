using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Message p)
        //{
            
        //    //mesaji gonderdigimiz tarih db ye kayıt olsun istedik
        //    p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    //durumu aktif yani okunmadi. okudugumuzda false olacak ileride
        //    p.Status = true;
        //    messageManager.TAdd(p);
        //    return View();
        //}
    }
}
