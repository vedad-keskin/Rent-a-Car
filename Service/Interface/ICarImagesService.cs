using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Responses.CarImages;
using RentACar.DataModels.Requests.CarImges;

namespace RentACar.Service.Interface
{
    public interface ICarImagesService
    {

        public List<CarImages> GetAll();
        public CreateCarImagesResponse CreateNewCarImages(CreateCarImagesRequest request);
        public CreateCarImagesResponse Update(UpsertCarImagesRequest request);
        public CommonResponse Delete(int id);
    }
}
