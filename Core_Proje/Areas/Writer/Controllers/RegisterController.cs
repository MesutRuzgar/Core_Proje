using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {
        //userManager Identity ilye birlikte gelen manager
        //readonly ile sadece okunabilir yaptık
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //async method kullandiğimiz icin async yaptik burayida
        public  async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    Email = p.Mail,
                    ImageUrl = p.ImageUrl

                };
                //async değere atatık createasync ise yeni bir hesap olusturmak icin identity
                //kutuphanesinden yararlanındı
                var result = await _userManager.CreateAsync(w, p.Password);

                if (result.Succeeded)
                {
                    //basarili olursa login e yonlendiriyoruz
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        //yanlıs olursa hata aciklamasini göster dedik
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
         
            return View();
        }
    }
}
