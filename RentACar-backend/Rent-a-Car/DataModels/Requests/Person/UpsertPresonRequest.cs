namespace RentACar.DataModels.Requests.Person
{
    public class UpsertPresonRequest
    {
        public int PresonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
