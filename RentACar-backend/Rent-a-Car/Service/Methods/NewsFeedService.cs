using RentACar.DataModels.Requests.NewsFeed;
using RentACar.DataModels.Requests.Recensions;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.NewsFeed;
using RentACar.DataModels.Responses.Recensions;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly ApplicationDbContext Context = new ApplicationDbContext();

        public List<NewsFeed> GetAllNewsFeeds()
        {
            return Context.NewsFeeds.ToList();
        }

        public CreateNewsFeedResponse CreateNewNewsFeed(CreateNewNewsFeedRequest request)
        {
            var NewNewsFeed = new NewsFeed();
            {
                NewNewsFeed.Text = request.Text;
                NewNewsFeed.Image = request.Image;
            }

            Context.NewsFeeds.Add(NewNewsFeed);
            Context.SaveChanges();

            return new CreateNewsFeedResponse() { NewsFeed = NewNewsFeed };

        }
        public CreateNewsFeedResponse UpdateNewsFeed(UpsertNewsFeedRequest request)
        {
            var exist = Context.NewsFeeds.FirstOrDefault(x => x.NewsId == request.NewsId);
            if (exist != null)
            {

                exist.NewsId = request.NewsId;
                exist.Text = request.Text;
                exist.Image = request.Image;

                Context.NewsFeeds.Update(exist);
                Context.SaveChanges();

                return new CreateNewsFeedResponse() { NewsFeed = exist };
            }

            else
            { return null; }
        }


        public CommonResponse DeleteNewsFeed(int id)
        {
            var removeNewsFeed = Context.NewsFeeds.FirstOrDefault(x => x.NewsId == id);
            Context.NewsFeeds.Remove(removeNewsFeed);
            Context.SaveChanges();

            return new CommonResponse() { ObjectId = id, Message = "Successfully removed!" };
        }

    }

}

