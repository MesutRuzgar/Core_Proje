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
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        //sag tıkla view ekle
        public IActionResult Index()
        {
            ViewBag.d1 = "Düzenleme";
            ViewBag.d2 = "Öne Çıkanlar";
            ViewBag.d3 = "Öne Çıkan Sayfası";
            //id 1 vermemizin sebebi feature managerda her zaman bir id ile calisacaz
            //o id ise "1"
            var values = featureManager.TGetById(1);
            return View(values);
        }
        
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            //default eklememizin sebebi default indexte calisacaz surekli
            return RedirectToAction("Index","Default");
        }
    }
}
