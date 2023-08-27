using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGetByIdList(int id)
        {
            var c = new Context();
            var value = c.Categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            var c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Created("",category);
         
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var c = new Context();
            var delete = c.Categories.Find(id);
            if (delete==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(delete);
                c.SaveChanges();
                return NoContent();
            }            
        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            var c = new Context();
            var update = c.Find<Category>(p.CategoryId);
            if (update == null)
            {
                return NotFound();
            }
            else
            {
                update.CategoryName = p.CategoryName;
                c.Update(update);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
