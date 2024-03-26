using RentACar.DataModels.Requests.UserStatus;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.UserStatus;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class UserStatusServise : IUserStatusSevice
    {
        private readonly DBContext.ApplicationDbContext dbContext = new DBContext.ApplicationDbContext();

        public List<UserStatus> GetAllUserStatus()
        {
            return dbContext.UserStatus.ToList();
        }

        public CreateUserStatusResponse CreateNewUserStatus(CreateUserStatusRequest request)
        {
            var newUser = new UserStatus()
            {
                Restricted = request.Restricted,
                UserId = request.UserId,
            };
            dbContext.UserStatus.Add(newUser);
            dbContext.SaveChanges();

            return new CreateUserStatusResponse() { UserStatus = newUser };
        }

        public CreateUserStatusResponse UpdateUserStatus(UpsertUserStatusRequest request)
        {
            var existStatus = dbContext.UserStatus.FirstOrDefault(x => x.UserStatusId == request.UserStatusId);
            if (existStatus != null)
            {
                existStatus.UserId = request.UserId;
                existStatus.Restricted = request.Restricted;

                dbContext.UserStatus.Update(existStatus);
                dbContext.SaveChanges();

                return new CreateUserStatusResponse() { UserStatus = existStatus };
            }
            else return null;
        }

        public CommonResponse DeleteUserStatus(int id)
        {
            var removeStatus=dbContext.UserStatus.FirstOrDefault(x=>x.UserStatusId==id);    
            dbContext.UserStatus.Remove(removeStatus); dbContext.SaveChanges();

            return new CommonResponse() { ObjectId = id , Message="Successfully deleted!"};
        }
    }
}
