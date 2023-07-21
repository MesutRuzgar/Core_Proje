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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.d1 = "Yetenek Listesi";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.d1 = "Yetenek Ekleme";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            //ekleme islemini gerceklestirip indexe aktar beni dedik
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }


        //buranın amacı güncelleme sayfasına admini aktarmak
        [HttpGet]
        //view ekliyoruz ve layouta bagli olarak calısacak
        public IActionResult EditSkill(int id)
        {
            ViewBag.d1 = "Yetenek Güncelleme";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Güncelleme";
            var values = skillManager.TGetById(id);
            return View(values);

        }

        //buranın amacı guncelleme sayfasındaki verileri db ye gondermek
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }

    }
}
