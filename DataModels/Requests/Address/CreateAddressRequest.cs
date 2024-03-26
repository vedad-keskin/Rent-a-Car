namespace RentACar.DataModels.Requests.Address
{
    public class CreateAddressRequest
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public int Number {  get; set; }

        public int CityId { get; set; }

    }
}
