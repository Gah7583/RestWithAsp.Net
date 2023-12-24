using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp.Net.Business;
using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Controllers
{
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    [ApiVersion("1")]
    public class BookController : Controller
    {
        private readonly IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Get() 
        {
            return Ok(_bookBusiness.GetBooks());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [MapToApiVersion("1")]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete]
        [MapToApiVersion("1")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
