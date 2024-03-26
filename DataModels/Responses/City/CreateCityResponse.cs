using RentACar.DBContext;
namespace RentACar.DataModels.Responses.City

{
    public class CreateCityResponse
    {
        public DBContext.City City { get; set; }
    }
}