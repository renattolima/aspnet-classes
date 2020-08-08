using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class01.Model;
using class01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace class01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {

        private IPersonService _personService;

        private readonly ILogger<PersonsController> _logger;

        // public PersonsController(ILogger<PersonsController> logger)
        // {
        //     _logger = logger;
        // }

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if(person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if(person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
