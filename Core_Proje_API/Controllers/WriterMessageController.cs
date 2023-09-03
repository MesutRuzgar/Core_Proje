using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterMessageController : ControllerBase
    {
        IWriterMessageService _writerMessageService;

        public WriterMessageController(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var values = _writerMessageService.TGetList();
            return Ok(values);

        }
        [HttpGet("getid")]
        public IActionResult GetById(int id)
        {
            var values = _writerMessageService.TGetById(id);
            return Ok(values);

        }
        [HttpPost("add")]
        public IActionResult Add(WriterMessage p)
        {
            _writerMessageService.TAdd(p);
            return Ok(new { message = "Başarıyla eklendi." });

        }
        [HttpPost("update")]
        public IActionResult Update(WriterMessage p)
        {
            _writerMessageService.TUpdate(p);
            return Ok(new { message = "Başarıyla güncellendi." });

        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var delete = _writerMessageService.TGetById(id);
            if (delete == null)
            {
                return NotFound(new { message = "Belirtilen özellik bulunamadı." });
            }
            else
            {
                _writerMessageService.TDelete(delete);
                return Ok(new { message = "Başarıyla silindi." });
            }

        }
    }
}
