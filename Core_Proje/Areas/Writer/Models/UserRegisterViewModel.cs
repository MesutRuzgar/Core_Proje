
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen  Soyadınızı Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
       
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen Aynı Şifre Girdiğinizden Emin Olunuz")]
        public string ConfrimPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        [EmailAddress(ErrorMessage = "Geçersiz Mail Adresi Girdiniz.")]
        public string Mail { get; set; }

    }
}
