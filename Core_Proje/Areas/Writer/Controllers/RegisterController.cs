using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
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
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                if (p.Picture!=null)
                {
                    //resmin kaynagini alıyoruz once
                    var resource = Directory.GetCurrentDirectory();
                    //uzantisini aliyoruz
                    var extension = Path.GetExtension(p.Picture.FileName);
                    //benzersiz bir resim adı olusturduk ve uzantidan gelen adi sonuna ekledik
                    var imagename = Guid.NewGuid() + extension;
                    //resmin kaydedilecegi yolu belirledik 
                    var savelocation = resource + "/wwwroot/userimage/" + imagename;
                    //yukarida ki kod bloklarini gerceklestirip resim dosyasını olusturduk
                    var stream = new FileStream(savelocation, FileMode.Create);
                    //streamdan gelen akis degerine resmi kopyaladik
                    await p.Picture.CopyToAsync(stream);
                    //kullanicinin imageurl si image nameden gelen deger olacak
                    p.ImageUrl = imagename;
                }
                    
              
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    Email = p.Mail,     
                    ImageUrl=p.ImageUrl
                };

                //async değere atatık createasync ise yeni bir hesap olusturmak icin identity
                //kutuphanesinden yararlanındı
                if (p.ConfrimPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(w, p.Password);


                    if (result.Succeeded)
                    {
                        //basarili olursa login e yonlendiriyoruz
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            //yanlıs olursa hata aciklamasini göster dedik
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }

                }
            }
         

            return View();
        }
    }
}
