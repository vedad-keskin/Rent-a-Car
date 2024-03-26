namespace RentACar.DataModels.Requests.Recensions
{
    public class UpserteRecensionsRequest
    {

        public int RecensionId { get; set; }
        public int StarRating { get; set; }
        public string Messages { get; set; }
    }
}
