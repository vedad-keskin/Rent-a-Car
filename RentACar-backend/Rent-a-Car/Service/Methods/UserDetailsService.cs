using RentACar.DataModels.Requests.UserDetails;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.UserDetails;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class UserDetailsService:IUserDetailsService
    {
        private readonly DBContext.ApplicationDbContext context= new DBContext.ApplicationDbContext();
        
        public List<UserDetails> GelAllUserDetails()
        {
            return context.UserDetails.ToList();
        }

        public CreateUserDetailsResponse CreateNewUserDetails(CreateUserDetailsRequest request)
        {
            var newUser = new UserDetails()
            {
                UserId = request.UserId,
                Verification = request.Verification,

            };
            context.UserDetails.Add(newUser);
            context.SaveChanges();
            return new CreateUserDetailsResponse() { UserDetails = newUser };
        }

        public CreateUserDetailsResponse UpdateUserDetails(UpsertUserDetailsRequest request)
        {
            var existUserDetails=context.UserDetails.FirstOrDefault(x=>x.UserDetailsId==request.UserDetailsId);
            if (existUserDetails != null)
            {
                existUserDetails.Verification = request.Verification;
                existUserDetails.UserId = request.UserId;

                context.UserDetails.Update(existUserDetails);
                context.SaveChanges();
                return new CreateUserDetailsResponse() { UserDetails = existUserDetails };
            }
            else return null;
        }

        public CommonResponse DeleteUserDetails(int id)
        {
            var Remove=context.UserDetails.FirstOrDefault(x=>x.UserDetailsId== id);
            context.UserDetails.Remove(Remove);
            context.SaveChanges();

            return new CommonResponse() { ObjectId = id ,Message="Successfully removed!"};
        }
    }
}
