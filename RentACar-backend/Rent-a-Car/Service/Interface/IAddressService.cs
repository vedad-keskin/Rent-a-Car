using RentACar.DataModels.Requests.Address;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Address;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IAddressService
    {
        public List<Address> GetAll();
        public CreateAddressResponse CreateNewAddress(CreateAddressRequest request);
        public CreateAddressResponse Update(UpsertAddressRequest request);
        public CommonResponse Delete(int id);


    }
}
