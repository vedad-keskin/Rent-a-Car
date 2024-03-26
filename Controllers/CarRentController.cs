using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Requests.CarRent;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentController : ControllerBase
    {

        public ICarRentService service { get; set; }

        public CarRentController(ICarRentService service)
        {
            this.service = service;
        }


        [HttpGet("GetAllCarRent")]

        public IActionResult GetAllCarRent()
        {
            var response = service.GetAll();
            return Ok(response);
        }


        [HttpPost("CreateNewCarRent")]
        public IActionResult CreateNewCarRent(CreateCarRentRequest request)
        {
            try
            {
                var response = service.CreateNewCarRent(request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("UpdateCarRentById")]
        public IActionResult UpdateCarRentById(UpsertCarRentRequest request)
        {
            try
            {
                var response = service.Update(request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("DeleteCarRentById")]
        public IActionResult DeleteCarRentById(int id)
        {
            return Ok(service.Delete(id));
        }







    }
}
