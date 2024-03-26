namespace RentACar.DataModels.Requests.CarImges
{
    public class UpsertCarImagesRequest
    {
        public int CarImageId { get; set; }
        public string ImageUrl { get; set; }
        public int CarId { get; set; }
    }
}
