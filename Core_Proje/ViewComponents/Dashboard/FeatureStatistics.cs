using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            //var values = contactManager.TGetList();
            return View();
        }

    }
}

