namespace RentACar.DataModels.Requests.Rent
{
    public class CreateRentRequest
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public string TypeOfPayment {  get; set; }
        public bool Installments {  get; set; }
        public int NumberOfInstallments { get; set; }

    }
}
