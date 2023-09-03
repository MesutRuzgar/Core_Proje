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
    public class AboutController : ControllerBase
    {
        IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = _aboutService.TGetList();
            return Ok(values);

        }
        [HttpGet("getid")]
        public IActionResult GetById(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);

        }
        [HttpPost("add")]
        public IActionResult Add(About about)
        {
            _aboutService.TAdd(about);
            return Ok(new { message = "Başarıyla eklendi." });

        }
        [HttpPost("update")]
        public IActionResult Update(About about)
        {
            _aboutService.TUpdate(about);
            return Ok(new { message = "Başarıyla güncellendi." });

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var delete = _aboutService.TGetById(id);
            if (delete == null)
            {
                return NotFound(new { message = "Belirtilen özellik bulunamadı." });
            }
            else
            {
                _aboutService.TDelete(delete);
                return Ok(new { message = "Başarıyla silindi." });
            }

        }
    }
}
