namespace RentACar.DataModels.Requests.User
{
    public class UpsertUserRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int PersonId {  get; set; }
    }
}
