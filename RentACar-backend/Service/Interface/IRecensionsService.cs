using RentACar.DataModels.Requests.Recensions;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Recensions;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IRecensionsService
    {
        public List<Recensions> GetAllRecensions();
        public CreateRecensionsResponse CreateNewRecensions(CreateNewRecensionsRequest request);
        public CreateRecensionsResponse UpdateRecensions(UpserteRecensionsRequest request);
        public CommonResponse DeleteRecensions(int id);
    }
}
