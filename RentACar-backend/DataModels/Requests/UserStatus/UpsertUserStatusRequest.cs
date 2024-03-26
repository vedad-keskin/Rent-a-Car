namespace RentACar.DataModels.Requests.UserStatus
{
    public class UpsertUserStatusRequest
    {
        public int UserStatusId { get; set; }
        public bool Restricted { get; set; }
        public int UserId { get; set; } 
    }
}
