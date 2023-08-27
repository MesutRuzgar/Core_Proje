using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.AdminNavbarProfile
{
    public class AdminNavbarProfile :ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminNavbarProfile(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;
            ViewBag.v2 = values.ImageUrl;
            return View();
        }
    }
}
