using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class DefaultController : Controller
    {
        //index e sağ tıklayıp viewden indexi buraya aldık en başta
        public IActionResult Index()
        {
            return View();
        }

        //parçalara bölüyoruz teker teker
        //sağ tıklayıp add view de sonra add view de razor view tıkla (2.)
        //Create as a partial view tikli olacak
        //Head kısmında veya başka bir partial i çağırmak için ;
        //@await Html.PartialAsync("HeaderPartial") kullanıyoruz. " " içerisine partiala verdiğimiz ismi yazıyoruz.
        //index üzerinden çağırdığımız ve index ise bağlı bulunduğu controller içinde olduğundan mütevellit yukarıdaki
        //gibi çağırıyoruz. Eğer ki kontroller farklı bir controller içersinde olsaydı " " içine onun view tarafındaki
        //yolu yazılacaktı.
        
        //indexten head kısmını kes ve HeaderPartial'a sağ tıkla Go to View diyerek içerisine yapıştır. Artık Head kısmımız burası oldu.
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return NavbarPartial();
        }


        //mesaj gonderme islemleri icin yaptık yeni partialleri olusturduk
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }


        //sendmessageye sag tiklayip wiew ekliyoruz, razor view, SendMessage isimli
        [HttpPost]
        public PartialViewResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            //mesaji gonderdigimiz tarih db ye kayıt olsun istedik
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //durumu aktif yani okunmadi. okudugumuzda false olacak ileride
            p.Status = true;
            messageManager.TAdd(p);
            return PartialView();
        }

    }
}
