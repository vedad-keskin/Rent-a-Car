using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Region;
using RentACar.DataModels.Requests.Rent;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        public IRegionService service { get; set; }
        public RegionController(IRegionService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllRegions")]
        public IActionResult GetAllRegions()
        {
            var response = service.GetAllRegions();
            return Ok(response);
        }

        [HttpPost("CreateNewRegion")]

        public IActionResult CreateNewRegion(CreateRegionRequest request)
        {
            var response = service.CreateNewRegion(request);
            return Ok(response);
        }

        [HttpPut("UpdateRegionById")]
        public IActionResult UpdateRegion(UpsertRegionRequest request)
        {
            var response = service.Update(request);
            return Ok();
        }

        [HttpDelete("DeleteRegionById")]
        public IActionResult DeleteRegion(int Id)

        {
            return Ok(service.DeleteRegion(Id));
        }

    }
}
