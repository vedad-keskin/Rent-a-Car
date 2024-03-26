using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Address;
using RentACar.DataModels.Requests.CarImges;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public ICarImagesService service { get; set; }

        public CarImagesController (ICarImagesService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllCarImages")]
        public IActionResult GetAllCarImages()
        {
            var response = service.GetAll();
            return Ok(response);
        }


        [HttpPost("CreateNewCarImages")]
        public IActionResult CreateNewCarImages(CreateCarImagesRequest request)
        {
            try
            {
                var response = service.CreateNewCarImages(request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("UpdateCarImagesById")]
        public IActionResult UpdateCarImages(UpsertCarImagesRequest request)
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

        [HttpDelete("DeleteCarImagesById")]
        public IActionResult DeleteCarImagesById(int id)
        {
            return Ok(service.Delete(id));
        }
        
    }
}
