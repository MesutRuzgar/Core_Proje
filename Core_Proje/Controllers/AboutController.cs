using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
