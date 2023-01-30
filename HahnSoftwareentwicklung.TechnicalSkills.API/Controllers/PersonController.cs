using HahnSoftwareentwicklung.TechnicalSkills.API.ApplicationServices;
using HahnSoftwareentwicklung.TechnicalSkills.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult>AddPerson(
            CreatePersonCommand createPersonCommand)
        {
            await apiServices.HandlerCommand(createPersonCommand);
            return Ok(createPersonCommand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetPerson(Guid id)
        {
            var response = await apiServices.GetPerson(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult>GetAllPersons()
        {
            var response = await apiServices.GetAllPerson();
            return Ok(response);
        }
    }
}
