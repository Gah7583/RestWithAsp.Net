using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp.Net.Model;
using RestWithAsp.Net.Services;

namespace RestWithAsp.Net.Controllers
{
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        [MapToApiVersion("1")]
        public IActionResult Put([FromBody] Person person)
        { 
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete]
        [MapToApiVersion("1")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
