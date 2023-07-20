using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {

        //sag tıkla view ekle
        public IActionResult Index()
        {
            return View();
        }
    }
}
