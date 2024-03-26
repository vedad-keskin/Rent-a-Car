using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Car;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService service { get; set; }
        public CarController(ICarService service) {

            this.service = service;

        }

        [HttpGet("GetAllCars")]
        public IActionResult GetAllCars()
        {
            //Car obj = new Car()
            //{
            //    Id = 235,
            //    Manufacturer = "BMW"

            //};

            var response = service.GetAll();
            return Ok(response);

        }

        [HttpPost ("CreateNewCar")]
        public IActionResult CreateNewCar( CreateCarRequest request)
        {
            var response = service.CreateNewCar(request);
            return Ok(response);
           

        }
        
        [HttpPut ("UpdateCarById")]
        public IActionResult UpdateCarById( UpsertCarRequest request )
        {
            return Ok();
        }

        [HttpDelete ("DeleteCarById")]
        public IActionResult DeleteCarById( int id)
        {
            return Ok(service.Delete(id));
        }




    }
}
