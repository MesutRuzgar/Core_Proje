using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly SignInManager<WriterUser> _signInManager;

        public ProfileController(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //sisteme otantike olan kullanıcının kullanıcı adına göre deger al
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Picture !=null)
            {
                //resmin kaynagini alıyoruz once
                var resource = Directory.GetCurrentDirectory();
                //uzantisini aliyoruz
                var extension = Path.GetExtension(p.Picture.FileName);
                //benzersiz bir resim adı olusturduk ve uzantidan gelen adi sonuna ekledik
                var imagename = Guid.NewGuid()+extension;
                //resmin kaydedilecegi yolu belirledik 
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                //yukarida ki kod bloklarini gerceklestirip resim dosyasını olusturduk
                var stream = new FileStream(savelocation, FileMode.Create);
                //streamdan gelen akis degerine resmi kopyaladik
                await p.Picture.CopyToAsync(stream);
                //kullanicinin imageurl si image nameden gelen deger olacak
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            if (p.Password !=null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                await _signInManager.SignOutAsync();
            
            }           
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
               
                return RedirectToAction("Index","Profile");
            }
            return View();
        }
    }
}
