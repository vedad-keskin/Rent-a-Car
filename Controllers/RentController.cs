using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Rent;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : ControllerBase
    {
        public IRentService service  {get;set;}
        public RentController (IRentService service)
        {
           this.service = service;
        }

        [HttpGet("GetAllRents")]

        public IActionResult GetAllRents() 
        { var response = service.GetAll(); 
            return Ok(response); 
        }

        [HttpPost("CreateNewRent")]

        public IActionResult CreateNewRent(CreateRentRequest request)
        {
            var response=service.CreateNewRent(request);
            return Ok(response);
        }

        [HttpPut("UpdateRentById")]
        public IActionResult UpdateRent(UpsertRentRequest request)
        {
            var response = service.Update(request);
            return Ok();
        }

        [HttpDelete("DeleteRentById")]
        public IActionResult DeleteRent(int Id)

        {
            return Ok(service.DeleteRent(Id));
        }

    }
}
