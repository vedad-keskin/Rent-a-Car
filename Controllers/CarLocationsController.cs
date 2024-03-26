using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Address;
using RentACar.DataModels.Requests.CarImges;
using RentACar.DataModels.Requests.CarLocations;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarLocationsController : ControllerBase
    {
        public ICarLocationsService service { get; set; }

        public CarLocationsController(ICarLocationsService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllCarLocations")]
        public IActionResult GetAllCarLocations()
        {
            var response = service.GetAll();
            return Ok(response);
        }

        [HttpPost("CreateNewCarLocations")]
        public IActionResult CreateNewCarLocations(CreateCarLocationsRequest request)
        {
            try
            {
                var response = service.CreateNewCarLocations(request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


    [HttpPut("UpdateCarLocationsById")]
    public IActionResult UpdateCarLocations(UpsertCarLocationsRequest request)
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




    [HttpDelete("DeleteCarLocationsById")]
        public IActionResult DeleteCarLocationsById(int id)
        {

        return Ok(service.Delete(id));
    }



    }
}
