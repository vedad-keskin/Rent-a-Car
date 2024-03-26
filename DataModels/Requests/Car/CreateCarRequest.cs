namespace RentACar.DataModels.Requests.Car
{
    public class CreateCarRequest
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int YearOfManufacture { get; set; }
        public double Mileage { get; set; }
        public string Type { get; set; }
        public bool Used { get; set; }
        public bool Registred { get; set; }
    }
}
