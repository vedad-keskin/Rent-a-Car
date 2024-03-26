using RentACar.DataModels.Requests.City;
using RentACar.DataModels.Responses.City;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.DataModels.Responses.User;
using RentACar.DataModels.Requests.User;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Service.Methods
{
    public class UserService:IUserService
    {
        private readonly DBContext.DbSetContext context=new DbSetContext();
        public List<User> GetAll()
        {
            return context.User.Include(x=> x.Person).ToList();
        }
        public CreateUserResponse CreateNewUser(CreateUserRequest request)
        {
            var AddNewUser = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PersonId = request.PersonId,
            };
            context.User.Add(AddNewUser);
            context.SaveChanges();

            return new  CreateUserResponse() { User= AddNewUser };
        }
        public CreateUserResponse UpdateUserById(UpsertUserRequest request)
        {
            var existUser = context.User.FirstOrDefault(x => x.UserId == request.UserId);
            if (existUser != null)
            {
                existUser.UserName = request.UserName;
                existUser.Email = request.Email;
                existUser.Password = request.Password;
                existUser.PersonId = request.PersonId;

                context.User.Add(existUser); 
                context.SaveChanges();
                return new CreateUserResponse() { User = existUser };

            }
            else return null;
        }

        public CommonResponse DeleteUserById(int id)
        {
            var RemoveUser=context.User.FirstOrDefault(x=>x.UserId == id);
            context.User.Remove(RemoveUser);
            context.SaveChanges();
            return new CommonResponse() { ObjectId = id ,Message="Successfully removed!"};
        }


       
    }
}
