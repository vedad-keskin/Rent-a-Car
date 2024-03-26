using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailsController : ControllerBase
    {

        public ICarDetailsService service { get; set; }

        public CarDetailsController(ICarDetailsService service)
        {
            this.service = service;
        }


        [HttpGet("GetAllCarDetails")]

        public IActionResult GetAllCarDetails()
        {
            var response = service.GetAll();
            return Ok(response);    
        }


        [HttpPost ("CreateNewCarDetails")]
        public IActionResult CreateNewCarDetails (CreateCarDetailsRequest request)
        {
            try
            {
            var response = service.CreateNewCarDetails(request);
            return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut ("UpdateCarDetailsById")]
        public IActionResult UpdateCarDetailsById (UpsertCarDetailsRequest request) {

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

        [HttpDelete ("DeletCarDetailsById")]
        public IActionResult DeleteCarDetailsById(int id)
        {
            return Ok(service.Delete(id));
        }





    }
}
