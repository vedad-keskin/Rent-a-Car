using RentACar.DataModels.Requests.Recensions;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Recensions;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class RecensionsService : IRecensionsService
    {
        private readonly ApplicationDbContext Context = new ApplicationDbContext();

        public List<Recensions> GetAllRecensions()
        {
            return Context.Recensions.ToList();
        }

        public CreateRecensionsResponse CreateNewRecensions(CreateNewRecensionsRequest request) {

            var newRecension = new Recensions();
            {
                newRecension.StarRating = request.StarRating;
                newRecension.Messages = request.Messages;
            }

            Context.Recensions.Add(newRecension);
            Context.SaveChanges();

            return new CreateRecensionsResponse() { Recensions=newRecension };
        }
         public CreateRecensionsResponse UpdateRecensions(UpserteRecensionsRequest request)
        {
            var exist = Context.Recensions.FirstOrDefault(x=>x.RecensionsId==request.RecensionId);
            if(exist != null) { 
            
                exist.RecensionsId = request.RecensionId;
                exist.StarRating = request.StarRating;
                exist.Messages = request.Messages;

                Context.Recensions.Update(exist);
                Context.SaveChanges();

                return new CreateRecensionsResponse() { Recensions = exist };
            }

            else
            { return null;}


        }

        public CommonResponse DeleteRecensions(int id)
        {
            var removeRecensions = Context.Recensions.FirstOrDefault(x => x.RecensionsId == id);
            Context.Recensions.Remove(removeRecensions);
            Context.SaveChanges();

            return new CommonResponse() { ObjectId = id, Message = "Successfully removed!" };
        }
    }
}
