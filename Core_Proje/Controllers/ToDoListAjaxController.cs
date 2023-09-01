using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class ToDoListAjaxController : Controller
    {
        ToDoListManager toDoManager = new ToDoListManager(new EfToDoListDal());
      
        [HttpPost]
        public IActionResult Add(ToDoList p)
        {
            p.Status = false;
            toDoManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
     
        public IActionResult Delete(int id)
        {
            var values = toDoManager.TGetById(id);
            toDoManager.TDelete(values);
            return NoContent();
        }
               
    }
}
