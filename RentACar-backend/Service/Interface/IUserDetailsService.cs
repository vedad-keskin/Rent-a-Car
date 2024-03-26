using RentACar.DataModels.Requests.UserDetails;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.UserDetails;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IUserDetailsService
    {
        public List<UserDetails> GelAllUserDetails();
        public CreateUserDetailsResponse CreateNewUserDetails(CreateUserDetailsRequest request);
        public CreateUserDetailsResponse UpdateUserDetails(UpsertUserDetailsRequest request);

        public CommonResponse DeleteUserDetails(int id);
    }
}
