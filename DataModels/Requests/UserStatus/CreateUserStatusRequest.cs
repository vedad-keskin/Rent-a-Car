namespace RentACar.DataModels.Requests.UserStatus
{
    public class CreateUserStatusRequest
    {
        public int UserStatusId { get; set; }
        public bool Restricted { get; set; }
        public int UserId { get; set; }
    }
}
