using RentACar.DataModels.Requests.Country;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.City;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class CountryService : ICountryService
    {
        private readonly DbSetContext context = new DbSetContext();

        public List<Country> GetAll()
        {
            return context.Country.ToList();
        }
        public CreateCountryResponse CreateNewCountry(CreateCountryRequest request)
        {
            var newCountry = new Country() {
            Name = request.Name
            };
            context.Country.Add(newCountry);
            context.SaveChanges();

            return new CreateCountryResponse {
            Country= newCountry
            };
        }

        public CommonResponse Delete(int id)
        {
            var countryRemove=context.Country.FirstOrDefault(c => c.CountryId==id);


            if (countryRemove!=null)
            {
            context.Country.Remove(countryRemove);
                context.SaveChanges();
                return new CommonResponse() { ObjectId=id, Message="successfully removed" };
            }
            else
            {
                return new CommonResponse() { ObjectId=id, Message="country with provided id does not exist" };

            }
        }


        public CreateCountryResponse Update(UpsertCountryRequest request)
        {
            var existCountry = context.Country.FirstOrDefault(x => x.CountryId == request.CountryId);
            if (existCountry != null)
            {

                existCountry.Name = request.Name;

                context.Country.Update(existCountry);
                context.SaveChanges();

                return new CreateCountryResponse { Country = existCountry };
            }
            else return null;
           
        }
    }
}
