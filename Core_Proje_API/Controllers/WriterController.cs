using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = _writerService.TGetList();
            return Ok(values);

        }
        [HttpGet("getid")]
        public IActionResult GetById(int id)
        {
            var values = _writerService.TGetById(id);
            return Ok(values);

        }
        [HttpPost("add")]
        public IActionResult Add(WriterUser writer)
        {
            _writerService.TAdd(writer);
            return Ok(new { message = "Başarıyla eklendi." });

        }
        [HttpPost("update")]
        public IActionResult Update(WriterUser writer)
        {
            _writerService.TUpdate(writer);
            return Ok(new { message = "Başarıyla güncellendi." });

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var delete = _writerService.TGetById(id);
            if (delete == null)
            {
                return NotFound(new { message = "Belirtilen özellik bulunamadı." });
            }
            else
            {
                _writerService.TDelete(delete);
                return Ok(new { message = "Başarıyla silindi." });
            }

        }
    }
}
