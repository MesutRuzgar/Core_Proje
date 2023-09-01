using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        private readonly UserManager<WriterUser> _userManager;
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public SlideList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user.Name + " " + user.Surname;
            var aboutImage = aboutManager.TGetById(1);
            ViewBag.v2 = aboutImage.ImageUrl;
            var feature = featureManager.TGetById(1);
            ViewBag.v3 = feature.Title;
            var values = portfolioManager.TGetList();
            return View(values);
        }
    }
}
