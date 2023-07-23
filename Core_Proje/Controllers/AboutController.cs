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
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

       
        public IActionResult Index()
        {
            ViewBag.d1 = "Düzenleme";
            ViewBag.d2 = "Hakkımda";
            ViewBag.d3 = "Hakkımda Sayfası";
            //id 1 vermemizin sebebi feature managerda her zaman bir id ile calisacaz
            //o id ise "1"
            var values = aboutManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.TUpdate(about);
            //default eklememizin sebebi default indexte calisacaz surekli
            return RedirectToAction("Index", "Default");
        }
    }
}
