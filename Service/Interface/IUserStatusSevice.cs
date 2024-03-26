using RentACar.DataModels.Requests.UserStatus;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.UserStatus;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IUserStatusSevice
    {
        public List<UserStatus> GetAllUserStatus();
        public CreateUserStatusResponse CreateNewUserStatus(CreateUserStatusRequest request);
        public CreateUserStatusResponse UpdateUserStatus(UpsertUserStatusRequest request);
        public CommonResponse DeleteUserStatus(int id);
    }
}
