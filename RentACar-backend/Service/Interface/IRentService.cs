using RentACar.DataModels.Requests.Rent;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Rent;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IRentService
    {
        public List<Rent> GetAll();
        public CreateRentResponse CreateNewRent(CreateRentRequest request);
        public CreateRentResponse Update(UpsertRentRequest request);
        public CommonResponse DeleteRent(int id);
    }
}
