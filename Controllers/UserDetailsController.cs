using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.UserDetails;
using RentACar.DataModels.Responses.UserDetails;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController:ControllerBase
    {
        public IUserDetailsService service { get; set; }

        public UserDetailsController(IUserDetailsService service)
        {
            this.service = service;
        }

        [HttpGet("GetAllUserDetails")]
        public IActionResult GetAllUserDetails() 
        { 
            var response=service.GelAllUserDetails();
            return Ok(response);
        
        }
        [HttpPost("CreateNewUserDetail")]

        public IActionResult CreateNewUserDetails(CreateUserDetailsRequest  request)
        {
            var response=service.CreateNewUserDetails(request);
            return Ok(response);
        }

        [HttpPut("UpdateUserDetails")]

        public IActionResult UpdateUserDetails(UpsertUserDetailsRequest request)
        {
            return Ok(service.UpdateUserDetails(request));
        }

        [HttpDelete("DeleteUserDetails")]
       public  IActionResult DeleteUserDetails(int id)
        {
            return Ok(service.DeleteUserDetails(id));
        }
    }
}
