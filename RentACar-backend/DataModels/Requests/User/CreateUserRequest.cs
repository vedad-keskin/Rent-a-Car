namespace RentACar.DataModels.Requests.User
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int PersonId { get; set; }

    }
}
