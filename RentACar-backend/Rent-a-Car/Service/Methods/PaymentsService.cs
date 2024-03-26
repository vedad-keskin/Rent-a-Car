using RentACar.DataModels.Requests.Recensions;
using RentACar.DataModels.Responses.Recensions;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.DataModels.Responses.Payments;
using RentACar.DataModels.Requests.Payments;

namespace RentACar.Service.Methods
{
    public class PaymentsService:IPaymentsService
    {

        //public List<Payments> GetAllPayments();
        //public CreatePaymentsResponse CreateNewPayment(CreatePaymentsRequest request);
        //public CreatePaymentsResponse UpdatePayments(UpsertPaymentsRequest request);
        //public CommonResponse DeletePayments(int id);
        private readonly ApplicationDbContext Context = new ApplicationDbContext();

        public List<Payments> GetAllPayments()
        {
            return Context.Payments.ToList();
        }

        public CreatePaymentsResponse CreateNewPayment(CreatePaymentsRequest request)
        {

            var newPayments = new Payments();
            {
               
                newPayments.PaymentMethod = request.PaymentMethod;
                newPayments.PaymentDate = request.PaymentDate;
                newPayments.TransactionId= request.TransactionId;
            }

            Context.Payments.Add(newPayments);
            Context.SaveChanges();

            return new CreatePaymentsResponse() { Payments = newPayments };
        }
        public CreatePaymentsResponse UpdatePayments(UpsertPaymentsRequest request)
        {
            var exist = Context.Payments.FirstOrDefault(x => x.PaymentId == request.PaymentId);
            if (exist != null)
            {

                exist.PaymentId = request.PaymentId;
                exist.PaymentDate = request.PaymentDate;
                exist.PaymentMethod = request.PaymentMethod;
                exist.TransactionId = request.TransactionId;

                Context.Payments.Update(exist);
                Context.SaveChanges();

                return new CreatePaymentsResponse() { Payments = exist };
            }

            else
            { return null; }


        }

        public CommonResponse DeletePayments(int id)
        {
            var removePayments = Context.Payments.FirstOrDefault(x => x.PaymentId == id);
            Context.Payments.Remove(removePayments);
            Context.SaveChanges();

            return new CommonResponse() { ObjectId = id, Message = "Successfully removed!" };
        }
    }

}
