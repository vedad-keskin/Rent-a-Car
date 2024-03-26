namespace RentACar.DataModels.Requests.Person
{
    public class CreatePersonRequest
    {
        public string  FirstName{ get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime BirthDate{ get; set; }
    }
}
