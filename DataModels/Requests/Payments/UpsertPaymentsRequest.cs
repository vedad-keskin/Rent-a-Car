namespace RentACar.DataModels.Requests.Payments
{
    public class UpsertPaymentsRequest
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TransactionId { get; set; }
    }
}
