using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Address;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public IAddressService service { get; set; }

        public AddressController(IAddressService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllAddress")]
        public IActionResult GetAllAddress()
        {
            var response = service.GetAll();
            return Ok(response);
        }


        [HttpPost("CreateNewAddress")]
        public IActionResult CreateNewAdress(CreateAddressRequest request)
        {
            var response=service.CreateNewAddress(request);
            return Ok(response);

        }

        [HttpPut("UpdateAddressById")]
        public IActionResult UpdateAddressById(UpsertAddressRequest request)
        {
            var response = service.Update(request);
            return Ok(response);
        }

        [HttpDelete("DeleteAddressById")]
        public IActionResult DeleteAddressById(int id)
        {
            var response=service.Delete(id);
            return Ok(response);
        }



    }
}
