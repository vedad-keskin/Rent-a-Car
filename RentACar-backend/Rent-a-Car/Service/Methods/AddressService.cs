using RentACar.DataModels.Requests.Address;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Address;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public List<Address> GetAll()
        {
            return context.Address.ToList();
        }


        public CreateAddressResponse CreateNewAddress(CreateAddressRequest request)
        {
            var NewAddress = new Address()
            {
                Name = request.Name,
                Number = request.Number,
                CityId = request.CityId,
            };
            context.Address.Add(NewAddress);
            context.SaveChanges();

            return new CreateAddressResponse() { Address=NewAddress  };
        }


       public CreateAddressResponse Update (UpsertAddressRequest request) 
        {
            var exist = context.Address.FirstOrDefault(x => x.AddressId == request.AddressId);
            if (exist != null)
            {
                exist.Name = request.Name;
                exist.Number = request.Number;
                exist.CityId = request.CityId;

                context.Address.Update(exist);
                context.SaveChanges();

                return new CreateAddressResponse() { Address = exist };
            }
            else return null;
        }

        public CommonResponse Delete (int id)
         {
            var removeAddress=context.Address.FirstOrDefault(x=>x.AddressId == id);
            context.Address.Remove(removeAddress); context.SaveChanges();

            return new CommonResponse() { ObjectId = id, Message="Successfully removed !" };
        }



    }
}
