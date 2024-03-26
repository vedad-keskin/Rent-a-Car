using RentACar.DataModels.Requests.CarImges;
using RentACar.DataModels.Responses.CarImages;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Responses.CarLocations;
using RentACar.DataModels.Requests.CarLocations;

namespace RentACar.Service.Interface
{
    public interface ICarLocationsService
    {
        public List<CarLocations> GetAll();
        public CreateCarLocationsResponse CreateNewCarLocations(CreateCarLocationsRequest request);
        public CreateCarLocationsResponse Update(UpsertCarLocationsRequest request);
        public CommonResponse Delete(int id);


    }
}
