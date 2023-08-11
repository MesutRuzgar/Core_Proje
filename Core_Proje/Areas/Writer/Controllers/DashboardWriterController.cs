using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class DashboardWriterController : Controller
    {
        
        private readonly UserManager<WriterUser> _userManager;

        public DashboardWriterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Area("Writer")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;
            return View();
        }
    }
}
