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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
           
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
         
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
