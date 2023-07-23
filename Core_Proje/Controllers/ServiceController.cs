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
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Hizmet Listesi";
            ViewBag.d2 = "Hizmetler";
            ViewBag.d3 = "Hizmet Listesi";
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.d1 = "Hizmet Ekleme";
            ViewBag.d2 = "Hizmetler";
            ViewBag.d3 = "Hizmet Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetById(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.d1 = "Hizmet Güncelleme";
            ViewBag.d2 = "Hizmetler";
            ViewBag.d3 = "Hizmet Güncelleme";
            var values = serviceManager.TGetById(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
