using RentACar.DataModels.Requests.City;
using RentACar.DataModels.Responses.City;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Service.Methods
{
    public class CityService:ICityService
    {
        private readonly DbSetContext context=new DbSetContext();

        public List<City> GetAll()
        {
            var response = context.City.Include(x=>x.Country).ToList();
            return response;
        }
        public CreateCityResponse CreateNewCity(CreateCityRequest request)
        {
            var newCity = new City() { Name = request.Name, PostalNumber=request.PostalNumber, CountryId=request.CountryId };
            context.City.Add(newCity);
            context.SaveChanges();
            return new CreateCityResponse() { City = newCity };
        }

        public CommonResponse Delete(int id)
        {
            var cityRemove=context.City.FirstOrDefault(c=>c.CityId==id);
            if(cityRemove!=null) {
                context.City.Remove(cityRemove);

                return new CommonResponse() { ObjectId = id, Message = "Successsfully removed!" };
            }
            else
            {
                return new CommonResponse() { ObjectId = id, Message = "Country with provided id does not exist" };

            }


        }


        public CreateCityResponse Update(UpsertCityRequest request)
        {

            var exist = context.City.FirstOrDefault(x => x.CityId == request.CityId);

            if (exist != null)
            {
                if (request.CityName != null)
                    exist.Name = request.CityName;

                if (request.PostalNumber != null)
                    exist.PostalNumber = request.PostalNumber;

                context.City.Update(exist);
                context.SaveChanges();
                return new CreateCityResponse { City = exist };
            }

            else return null;


        }
    }
}
