namespace RentACar.DataModels.Requests.CarLocations
{
    public class UpsertCarLocationsRequest
    {
        public int CarId { get; set; }
        public int CarLocationsId { get; set; }
        public int LocationId { get; set;}
        public int CityId { get; set;} 
    }
}
