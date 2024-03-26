namespace RentACar.DataModels.Requests.City
{
    public class UpsertCityRequest
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string ?CityName {  get; set; }
        public string? PostalNumber { get; set; }
        
       
    }
}
