namespace RentACar.DataModels.Requests.UserDetails
{
    public class CreateUserDetailsRequest
    {
        public int UserDetailsId { get; set; }
        public bool Verification {  get; set; }

        public int UserId { get; set; }
    }
}
