namespace RentACar.DataModels.Requests.CarLocations
{
    public class CreateCarLocationsRequest
    {
        public int CarId { get; set; }
        public  int  LocationId { get; set; }

        public int CityId { get; set; }
    }
}
