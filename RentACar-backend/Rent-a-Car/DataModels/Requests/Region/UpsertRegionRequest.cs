namespace RentACar.DataModels.Requests.Region
{
    public class UpsertRegionRequest
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int CountryId { get; set; }
    }
}
