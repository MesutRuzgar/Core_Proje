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
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            ViewBag.d1 = "Deneyim Listesi";
            ViewBag.d2 = "Deneyimler";
            ViewBag.d3 = "Deneyim Listesi";
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.d1 = "Deneyim Ekleme";
            ViewBag.d2 = "Deneyimler";
            ViewBag.d3 = "Deneyim Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);           
            return RedirectToAction("Index");
        }
    }
}
