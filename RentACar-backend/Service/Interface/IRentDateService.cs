using RentACar.DataModels.Requests.Region;
using RentACar.DataModels.Requests.RentDate;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Region;
using RentACar.DataModels.Responses.RentDate;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IRentDateService
    {
        public List<RentDate> GetAllRentDates();

        public CreateRentDateResponse CreateNewRentDate(CreateRentDateRequest request);

        public CreateRentDateResponse Update(UpsertRentDateRequest request);

        public CommonResponse Delete(int id);
    }
}
