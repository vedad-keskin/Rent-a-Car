namespace RentACar.DataModels.Requests.NewsFeed
{
    public class UpsertNewsFeedRequest
    {
        public int NewsId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
    }
}
