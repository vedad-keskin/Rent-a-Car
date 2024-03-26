using RentACar.DataModels.Requests.Recensions;
using RentACar.DataModels.Responses.Recensions;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Requests.Payments;
using RentACar.DataModels.Responses.Payments;

namespace RentACar.Service.Interface
{
    public interface IPaymentsService
    {
        public List<Payments> GetAllPayments();
        public CreatePaymentsResponse CreateNewPayment(CreatePaymentsRequest request);
        public CreatePaymentsResponse UpdatePayments(UpsertPaymentsRequest request);
        public CommonResponse DeletePayments(int id);
    }
}
