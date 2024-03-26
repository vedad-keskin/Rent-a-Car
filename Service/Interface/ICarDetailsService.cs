using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface ICarDetailsService
    {

        public List<CarDetails> GetAll();
        public CreateCarDetailsResponse CreateNewCarDetails(CreateCarDetailsRequest request);
        public CreateCarDetailsResponse Update (UpsertCarDetailsRequest request);
        public CommonResponse Delete(int id);


    }
}
