namespace RentACar.DataModels.Requests.Rent
{
    public class UpsertRentRequest
    {
       
        public int Id { get; set; }
        public int NumberOfInstallments {  get; set; }

        public double TotalAmount { get; set; }
        public string TypeOfPayment { get; set; }
        public bool Installments { get; set; }
       
    }
}
