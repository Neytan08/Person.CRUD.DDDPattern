using HahnSoftwareentwicklung.TechnicalSkills.API.ApplicationServices;
using HahnSoftwareentwicklung.TechnicalSkills.API.Commands;
using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace HahnSoftwareentwicklung.TechnicalSkills.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly APIServices apiServices;

        public PersonController(APIServices apiServices) 
        { 
            this.apiServices = apiServices;
        }

        [HttpPost]
        public async Task<IActionResult>AddPerson(CreatePersonCommand createPersonCommand)
        {
            await apiServices.HandleCommandCreate(createPersonCommand);
            return Ok(createPersonCommand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetPerson(Guid id)
        {
            var response = await apiServices.GetPerson(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            List<Person> persons = await apiServices.GetAllPerson();

            return Ok(persons);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {            
            await apiServices.DeletePerson(id);
            
            return Ok(id);
        }
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(Guid id, Person person)
        {
            var personToUpdate = await apiServices.GetPerson(id);

            if (personToUpdate != null)
            {
                await apiServices.UpdatePerson(person);
                return Ok(person);
            }
            return null;
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(Guid id, UpdatePersonCommand updatePerson)
        {
            await apiServices.UpdatePerson(id, updatePerson);
            return Ok(updatePerson);
        }
    }
}
