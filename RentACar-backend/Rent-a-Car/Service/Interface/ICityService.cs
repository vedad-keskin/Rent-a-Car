using RentACar.DataModels.Requests.Country;
using RentACar.DataModels.Responses.City;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Requests.City;

namespace RentACar.Service.Interface
{
    public interface ICityService
    {
        public List<City> GetAll();
        public CreateCityResponse CreateNewCity(CreateCityRequest request);
        public CreateCityResponse Update(UpsertCityRequest request);
        public CommonResponse Delete(int id);
    }
}
