using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp.Net.Model;
using RestWithAsp.Net.Business;

namespace RestWithAsp.Net.Controllers
{
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    [ApiVersion("1")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personService)
        {
            _personBusiness = personService;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [MapToApiVersion("1")]
        public IActionResult Put([FromBody] Person person)
        { 
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete]
        [MapToApiVersion("1")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
