using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.UserStatus;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserStatusController:ControllerBase
    {
        public IUserStatusSevice service { get; set; }

        public UserStatusController(IUserStatusSevice service)
        {
            this.service = service;
        }

        [HttpGet("GetAllUserStatus")]
        public IActionResult GetAllUerStatus()
        {
            var response=service.GetAllUserStatus();
            return Ok(response);
        }

        [HttpPost("CreateNewUserStatus")]
        public IActionResult CreateNewUserStatus(CreateUserStatusRequest request)
        {
            var response=service.CreateNewUserStatus(request);
            return Ok(response);
        }

        [HttpPut("UpdateUserStatus")]
        public IActionResult UpdateUserStatus(UpsertUserStatusRequest request)
        {
            var response= service.UpdateUserStatus(request);
            return Ok(response);
        }

        [HttpDelete("DeleteUserStatus")]
        public IActionResult DeleteUserStatus(int id)
        {
            var respone=service.DeleteUserStatus(id);
            return Ok(respone);
        }
    }
}
