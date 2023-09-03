using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = _socialMediaService.TGetList();
            return Ok(values);

        }
        [HttpGet("getid")]
        public IActionResult GetById(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return Ok(values);

        }
        [HttpPost("add")]
        public IActionResult Add(SocialMedia socialMedia)
        {
            _socialMediaService.TAdd(socialMedia);
            return Ok(new { message = "Başarıyla eklendi." });

        }
        [HttpPost("update")]
        public IActionResult Update(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return Ok(new { message = "Başarıyla güncellendi." });

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var delete = _socialMediaService.TGetById(id);
            if (delete == null)
            {
                return NotFound(new { message = "Belirtilen özellik bulunamadı." });
            }
            else
            {
                _socialMediaService.TDelete(delete);
                return Ok(new { message = "Başarıyla silindi." });
            }

        }
    }
}
