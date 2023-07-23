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
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.d1 = "Proje Listesi ";
            ViewBag.d2 = "Projelerim";
            ViewBag.d3 = "Proje Listesi";
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.d1 = "Proje Ekleme ";
            ViewBag.d2 = "Projelerim";
            ViewBag.d3 = "Proje Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }

    }
}
