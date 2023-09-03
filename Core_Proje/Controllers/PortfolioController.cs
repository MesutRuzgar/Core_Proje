using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_Proje.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Portfolio portfolio = new Portfolio
                {
                    Name = viewModel.Name,
                    ImageUrl = viewModel.ImageUrl,
                    ProjectUrl = viewModel.ProjectUrl,
                    ImageUrl2 = viewModel.ImageUrl2,
                    Platform = viewModel.Platform,
                    Price = viewModel.Price,
                    Status = viewModel.Status,
                    Value = viewModel.Value
                };

                if (viewModel.Picture != null)
                {
                    var imageName1 = await UploadImage(viewModel.Picture);
                    portfolio.ImageUrl = imageName1;
                }

                if (viewModel.Picture2 != null)
                {
                    var imageName2 = await UploadImage(viewModel.Picture2);
                    portfolio.ImageUrl2 = imageName2;
                }

                if (portfolio.Value >= 100)
                {
                    portfolio.Status = true;
                }
                else
                {
                    portfolio.Status = false;
                }

                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }



        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetById(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]        
        public IActionResult EditPortfolio(int id)
        {
            
            var values = portfolioManager.TGetById(id);
            PortfolioViewModel viewModel = new PortfolioViewModel
            {
                PortfolioId = values.PortfolioId,
                Name = values.Name,
                ImageUrl = values.ImageUrl,
                ProjectUrl = values.ProjectUrl,
                ImageUrl2 = values.ImageUrl2,
                Platform = values.Platform,
                Price = values.Price,
                Status = values.Status,
                Value = values.Value
            };

            return View(viewModel);

        }


        //[HttpPost]
        //public IActionResult EditPortfolio(Portfolio portfolio)
        //{
        //    PortfolioValidator validations = new PortfolioValidator();
        //    ValidationResult result = validations.Validate(portfolio);
        //    if (result.IsValid)
        //    {
        //        if (portfolio.Value >= 100)
        //        {
        //            portfolio.Status = true;
        //        }
        //        else
        //        {
        //            portfolio.Status = false;
        //        }
        //        portfolioManager.TUpdate(portfolio);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }

        //    return View(portfolio);
        //}

        [HttpPost]
        public async Task<IActionResult> EditPortfolio(PortfolioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Portfolio existingPortfolio = portfolioManager.TGetById(viewModel.PortfolioId);

                if (existingPortfolio != null)
                {
                    existingPortfolio.Name = viewModel.Name;
                    existingPortfolio.ProjectUrl = viewModel.ProjectUrl;
                    existingPortfolio.Platform = viewModel.Platform;
                    existingPortfolio.Price = viewModel.Price;
                    existingPortfolio.Status = viewModel.Status;
                    existingPortfolio.Value = viewModel.Value;

                    if (viewModel.Picture != null)
                    {
                        var imageName1 = await UploadImage(viewModel.Picture);
                        existingPortfolio.ImageUrl = imageName1;
                    }

                    if (viewModel.Picture2 != null)
                    {
                        var imageName2 = await UploadImage(viewModel.Picture2);
                        existingPortfolio.ImageUrl2 = imageName2;
                    }

                    if (existingPortfolio.Value >= 100)
                    {
                        existingPortfolio.Status = true;
                    }
                    else
                    {
                        existingPortfolio.Status = false;
                    }

                    portfolioManager.TUpdate(existingPortfolio);
                    return Redirect("/Portfolio/EditPortfolio/"+viewModel.PortfolioId);

                }
                else
                {
                    // Hata durumu: Geçerli portföy bulunamadı.
                    // Burada hata mesajı oluşturabilir veya yönlendirme yapabilirsiniz.
                }
            }

            return View(viewModel); // Model geçersiz olduğunda
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
                    var saveLocation = Path.Combine(resource, "wwwroot/projectimage", imageName);

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
