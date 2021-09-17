using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Models;
using PersonApi.Repository;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPerson()
        {
            return await _personRepository.Get();
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Person>> GetPerson(int code)
        {
            return await _personRepository.Get(code);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody] Person person)
        {

            var newPerson = await _personRepository.Create(person);
            return CreatedAtAction(nameof(GetPerson), new { code = newPerson.Code }, newPerson);
        }

        [HttpPut]
        public async Task<ActionResult> PutPerson(int code, [FromBody] Person person)
        {
            if (code != person.Code)
            {
                return BadRequest();
            }

            await _personRepository.Update(person);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            var personToDelete = await _personRepository.Get(code);
            if (personToDelete == null)
                return NotFound();

            await _personRepository.Delete(personToDelete.Code);
            return NoContent();
        }
    }
}
