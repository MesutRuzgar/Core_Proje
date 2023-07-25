using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.d1 = "Dashboard";
            ViewBag.d2 = "İstatistikler";
            ViewBag.d3 = "İstatistik Sayfası";
            return View();
        }
    }
}
