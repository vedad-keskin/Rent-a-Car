using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Rent;
using RentACar.DataModels.Requests.RentDate;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentDateController : ControllerBase
    {
        public IRentDateService service { get; set; }
        public RentDateController(IRentDateService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllRentDate")]

        public IActionResult GetAllRentDates()
        {
            var response = service.GetAllRentDates();
            return Ok(response);
        }

        [HttpPost("CreateNewRentDate")]

        public IActionResult CreateNewRentDate(CreateRentDateRequest request)
        {
            var response = service.CreateNewRentDate(request);
            return Ok(response);
        }

        [HttpPut("UpdateRentDateById")]
        public IActionResult Update(UpsertRentDateRequest request)
        {
            var response = service.Update(request);
            return Ok();
        }

        [HttpDelete("DeleteRentDateById")]
        public IActionResult Delete(int Id)

        {
            return Ok(service.Delete(Id));
        }
    }
}
