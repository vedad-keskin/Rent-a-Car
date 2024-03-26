using RentACar.DataModels.Requests.CarImges;
using RentACar.DataModels.Responses.CarImages;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Responses.CarRent;
using RentACar.DataModels.Requests.CarRent;

namespace RentACar.Service.Interface
{
    public interface ICarRentService
    {
        public List<CarRent> GetAll();
        public CreateCarRentResponse CreateNewCarRent(CreateCarRentRequest request);
        public CreateCarRentResponse Update(UpsertCarRentRequest request);
        public CommonResponse Delete(int id);
    }
}
