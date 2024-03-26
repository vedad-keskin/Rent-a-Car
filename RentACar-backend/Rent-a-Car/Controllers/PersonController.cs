using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Person;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        public IPersonService service { get; set; }

        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var response = service.GetAll();
            return Ok(response);
        }


        [HttpPost("CreateNewPerson")]
        public IActionResult CreateNewPerson(CreatePersonRequest request)
        {
            var response=service.CreateNewPerson(request);
            return Ok(response);

        }

        [HttpPut("UpdatePersonById")]
        public IActionResult UpdatePersonById(UpsertPresonRequest request)
        {
            var response = service.Update(request);
            return Ok(response);
        }

        [HttpDelete("DeletePersonById")]
        public IActionResult DeletePersonById(int id)
        {
            var response = service.Delete(id);
            return Ok(response);
        }
       
    }
}
