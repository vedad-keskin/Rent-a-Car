using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RentACar.DataModels.Requests.Country;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.Service.Methods;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {

        public ICountryService service { get; set; }

        public CountryController(ICountryService service)
        {
                this.service=service;
        }


        [HttpGet("GetAllCountries")]
        public IActionResult GetAllCountries()
        {
            //data for testing method GetAllCountries
            //Country obj = new Country()
            //{
            //    Id = 345,
            //    Naziv = "Holandija"
            //};
            var response = service.GetAll();

            return Ok(response);
        }

        [HttpPost("CreateNewCountry")]
        public IActionResult CreateNewCountry(CreateCountryRequest request)
        {
            var response = service.CreateNewCountry(request);
            return Ok(response);
        }

        [HttpPut("UpdateCountryById")]
        public IActionResult UpdateCountryById(UpsertCountryRequest request)
        {
            return Ok(service.Update(request));
        }

        [HttpDelete("DeleteCountryById")]
        public IActionResult DeleteCountryById(int id)
        {
            return Ok(service.Delete(id));
        }

    }
}
