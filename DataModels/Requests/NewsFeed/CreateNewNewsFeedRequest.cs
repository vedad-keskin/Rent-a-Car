namespace RentACar.DataModels.Requests.NewsFeed
{
    public class CreateNewNewsFeedRequest
    {
        public int NewsId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
    }
}
