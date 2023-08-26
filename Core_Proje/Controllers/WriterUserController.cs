using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public IActionResult Index()
        {
           return View();
        }
        public IActionResult ListUser()
        {
            //veriyi JSON formatına donusturduk
            var values = JsonConvert.SerializeObject(writerManager.TGetList());
            return Json(values);
        }
    }
}
