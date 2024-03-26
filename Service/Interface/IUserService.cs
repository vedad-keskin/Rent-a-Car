using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Requests.User;
using RentACar.DataModels.Responses.User;

namespace RentACar.Service.Interface
{
    public interface IUserService
    {
        public List<User> GetAll();
        public CreateUserResponse CreateNewUser(CreateUserRequest request);
        public CreateUserResponse UpdateUserById(UpsertUserRequest request);
        public CommonResponse DeleteUserById(int id);
    }
}
