using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {

            ViewBag.c1 = c.Skills.Count();
            ViewBag.c2 = c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.c3 = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.c4 = c.Experiences.Count();
            return View();
        }

    }
}

