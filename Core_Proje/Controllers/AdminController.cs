using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }


    }
}
