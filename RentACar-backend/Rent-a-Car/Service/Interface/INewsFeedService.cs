using RentACar.DataModels.Requests.NewsFeed;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.NewsFeed;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface INewsFeedService
    {
        public List<NewsFeed> GetAllNewsFeeds();
        public CreateNewsFeedResponse CreateNewNewsFeed(CreateNewNewsFeedRequest request);
        public CreateNewsFeedResponse UpdateNewsFeed(UpsertNewsFeedRequest request);

        public CommonResponse DeleteNewsFeed(int id);

    }
}
