using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.City;
using RentACar.DataModels.Requests.User;
using RentACar.Service.Interface;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService service { get; set; }

        public UserController(IUserService service)
        {
            this.service = service;
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {

            var response = service.GetAll();

            return Ok(response);
        }

        [HttpPost("CreateNewUser")]
        public IActionResult CreateNewUser(CreateUserRequest request)
        {
            var response= service.CreateNewUser(request);
            return Ok(response);
        }

        [HttpPut("UpdateUserById")]
        public IActionResult UpdateUserById(UpsertUserRequest request)
        {
            return Ok(service.UpdateUserById(request));
        }

        [HttpDelete("DeleteUserById")]
        public IActionResult DeleteUserById(int id)
        {
            return Ok(service.DeleteUserById(id));
        }
    }

}

