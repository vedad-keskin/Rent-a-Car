using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.City;
using RentACar.DataModels.Requests.Country;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController :ControllerBase
    {
        public ICityService service { get; set; }

        public CityController(ICityService service)
        {
            this.service = service;
        }


        [HttpGet("GetAllCity")]
        public IActionResult GetAllCities()
        {
            
            var response = service.GetAll();

            return Ok(response);
        }

        [HttpPost("CreateNewCity")]
        public IActionResult CreateNewCity(CreateCityRequest request)
        {
            var response=service.CreateNewCity(request);
            return Ok(response);
        }

        [HttpPut("UpdateCityById")]
        public IActionResult UpdateCityById(UpsertCityRequest request)
        {
            return Ok(service.Update(request));
        }

        [HttpDelete("DeleteCityById")]
        public IActionResult DeleteCityById(int id)
        {
           return Ok(service.Delete(id));
        }
    }
}
