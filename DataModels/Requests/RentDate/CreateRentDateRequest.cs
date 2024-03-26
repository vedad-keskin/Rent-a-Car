namespace RentACar.DataModels.Requests.RentDate
{
    public class CreateRentDateRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int CarID { get; set; }
        public int RentID { get; set; }

    }
}
