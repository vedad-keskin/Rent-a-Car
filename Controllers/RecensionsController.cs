using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Recensions;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class RecensionsController:ControllerBase
    {
        public IRecensionsService Service { get; set;}
        public RecensionsController(IRecensionsService service)
        {
            this.Service= service;
        }

        [HttpGet("GetAllRecensions")]
        public IActionResult GetAllRecensions() { 
        
            var response=Service.GetAllRecensions();
            return Ok(response);
        }
        [HttpPost("CreateNewRecensions")]
        public IActionResult CreateNewRecensions(CreateNewRecensionsRequest request)
        {

            var response = Service.CreateNewRecensions(request);
            return Ok(response);
        }

        [HttpPut("UpdateRecensions")]
        public IActionResult UpdateRecensions(UpserteRecensionsRequest request)
        {
            var response = Service.UpdateRecensions(request);
            return Ok(response);
        }

        [HttpDelete("DeleteRecensionsById")]
        public IActionResult Delete(int id)
        {
            var response = Service.DeleteRecensions(id);
            return Ok(response);
        }
    }
}
