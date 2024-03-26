using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.NewsFeed;
using RentACar.DataModels.Requests.Recensions;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{

    [ApiController]
    [Route("Controller")]
    public class NewsFeedController:ControllerBase
    {
        public INewsFeedService Service { get; set; }
        public NewsFeedController(INewsFeedService service)
        {
            this.Service = service;
        }

        [HttpGet("GetAllNewsFeed")]
        public IActionResult GetAllNewsFeeds()
        {

            var response = Service.GetAllNewsFeeds();
            return Ok(response);
        }
        [HttpPost("CreateNewNewsFeeds")]
        public IActionResult CreateNewNewsFeeds(CreateNewNewsFeedRequest request)
        {

            var response = Service.CreateNewNewsFeed(request);
            return Ok(response);
        }

        [HttpPut("UpdateNewsFeeds")]
        public IActionResult UpdateNewsFeeds(UpsertNewsFeedRequest request)
        {
            var response = Service.UpdateNewsFeed(request);
            return Ok(response);
        }

        [HttpDelete("DeleteNewsFeedsById")]
        public IActionResult Delete(int id)
        {
            var response = Service.DeleteNewsFeed(id);
            return Ok(response);
        }
    }
}
