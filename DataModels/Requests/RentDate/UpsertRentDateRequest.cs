namespace RentACar.DataModels.Requests.RentDate
{
    public class UpsertRentDateRequest
    {
        public int RentDateID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int RentID { get; set; }
        public int CarID { get; set; }
    }
}
