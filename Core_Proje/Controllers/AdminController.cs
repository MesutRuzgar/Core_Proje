﻿using Microsoft.AspNetCore.Mvc;
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

        //footer bolumu icin
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        //navbar icin
        public PartialViewResult PartialNavbar()
        {
            return PartialNavbar();
        }

        //header
        public PartialViewResult PartialHead()
        {
            return PartialHead();
        }

        //scripts
        public PartialViewResult PartialScript()
        {
            return PartialScript();
        }

        //head kısmında bulunan sayfa isimlerini dinamik olarak almak icin olusturduk
        public PartialViewResult NavigationPartial()
        {
            return PartialView();
        }
    }
}
