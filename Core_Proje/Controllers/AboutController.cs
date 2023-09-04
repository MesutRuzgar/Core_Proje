using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());


        public IActionResult Index()
        {

            //id 1 vermemizin sebebi feature managerda her zaman bir id ile calisacaz
            //o id ise "1"
            var values = aboutManager.TGetById(1);
            AboutEditViewModel model = new AboutEditViewModel();
            model.Address = values.Address;
            model.Age = values.Age;
            model.Description = values.Description;
            model.ImageUrl = values.ImageUrl;
            model.Mail = values.Mail;
            model.Phone = values.Phone;
            model.Title = values.Title;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(AboutEditViewModel p)
        {
            var values = aboutManager.TGetById(1);
            if (p.Picture != null)
            {
                //resmin kaynagini alıyoruz once
                var resource = Directory.GetCurrentDirectory();
                //uzantisini aliyoruz
                var extension = Path.GetExtension(p.Picture.FileName);
                //benzersiz bir resim adı olusturduk ve uzantidan gelen adi sonuna ekledik
                var imagename = Guid.NewGuid() + extension;
                //resmin kaydedilecegi yolu belirledik 
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                //yukarida ki kod bloklarini gerceklestirip resim dosyasını olusturduk
                var stream = new FileStream(savelocation, FileMode.Create);
                //streamdan gelen akis degerine resmi kopyaladik
                p.Picture.CopyToAsync(stream);
                //kullanicinin imageurl si image nameden gelen deger olacak
                p.ImageUrl = imagename;
            }
            values.Address = p.Address;
            values.Age = p.Age;
            values.Description = p.Description;
            values.ImageUrl = p.ImageUrl;
            values.Mail = p.Mail;
            values.Phone = p.Phone;
            values.Title = p.Title;
            aboutManager.TUpdate(values);
            //default eklememizin sebebi default indexte calisacaz surekli
            return RedirectToAction("Index", "About");
        }
    }
}
