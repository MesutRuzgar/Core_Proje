using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = _contactService.TGetList();
            return Ok(values);

        }
        [HttpGet("getid")]
        public IActionResult GetById(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);

        }
        [HttpPost("add")]
        public IActionResult Add(Contact contact)
        {
            _contactService.TAdd(contact);
            return Ok(new { message = "Başarıyla eklendi." });

        }
        [HttpPost("update")]
        public IActionResult Update(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok(new { message = "Başarıyla güncellendi." });

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var delete = _contactService.TGetById(id);
            if (delete == null)
            {
                return NotFound(new { message = "Belirtilen özellik bulunamadı." });
            }
            else
            {
                _contactService.TDelete(delete);
                return Ok(new { message = "Başarıyla silindi." });
            }

        }
    }
}
