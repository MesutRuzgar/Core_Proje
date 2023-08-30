using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {

            var values = testimonialManager.TGetById(id);
            return View(values);

        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialViewModel p)
        {
          
            Testimonial testimonial = new Testimonial
            {
                ClientName = p.ClientName,
                Company = p.Company,
                Comment = p.Comment, 
                ImageUrl=p.ImageUrl
            };
            if (p.Picture != null)
            {
                var imageName = await UploadImage(p.Picture);
                testimonial.ImageUrl = imageName;
            }

            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }


        private async Task<string> UploadImage(IFormFile picture)
        {
            if (picture != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" }; // İzin verilen uzantılar
                var extension = Path.GetExtension(picture.FileName).ToLower();

                if (allowedExtensions.Contains(extension))
                {
                    var resource = Directory.GetCurrentDirectory();
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = Path.Combine(resource, "wwwroot/testimonialimage", imageName);

                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }

                    return imageName;
                }
                else
                {
                    //throw new Exception bir istisna olusturmak icin kullanilir buradaki amacimiz hatayi göstermek
                    throw new Exception("Geçersiz dosya uzantısı. Sadece JPG, JPEG ve PNG ve  uzantıları kabul edilir.");
                }
            }

            return null;
        }
    }

}






