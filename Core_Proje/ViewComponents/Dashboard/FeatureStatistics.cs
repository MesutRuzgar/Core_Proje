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
            //okunmamıslar
            var m1 = c.Messages.Where(x => x.Status == false).Count();
            var m2 = c.WriterMessages.Where(x => x.Status == false).Count();
            ViewBag.c2 = m1 + m2;
            //okunmuslar
            var m3 = c.Messages.Where(x => x.Status == true).Count();
            var m4 = c.WriterMessages.Where(x => x.Status == true).Count();          
            ViewBag.c3 = m3 + m4;

            //sayfadan gelen okunmamıs
            ViewBag.y = m1;
            //yazardan gelen okunmamıs
            ViewBag.y1 = m2;

            ViewBag.c4 = c.Experiences.Count();
            return View();
        }

    }
}

