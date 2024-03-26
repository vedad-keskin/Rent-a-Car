
using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Rent;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Rent;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class RentService:IRentService
    {
        private readonly DBContext.ApplicationDbContext context =new ApplicationDbContext();
        public List<Rent> GetAll()
        {
            var response = context.Rent.ToList();
            return response;
        }
      
        public CreateRentResponse CreateNewRent(CreateRentRequest request)
        {
           var newRent=new Rent() { TotalAmount=request.TotalAmount,TypeOfPayment=request.TypeOfPayment,
           Installments=request.Installments,NumberOfInstallments=request.NumberOfInstallments};
            context.Rent.Add(newRent);
            context.SaveChanges();
            return new CreateRentResponse() { Rent=newRent };
        }

        public CreateRentResponse Update(UpsertRentRequest request)
        {
            var existRent = context.Rent.FirstOrDefault(x => x.Id == request.Id);
            if (existRent != null)
            {
                existRent.TotalAmount = request.TotalAmount;
                existRent.TypeOfPayment = request.TypeOfPayment;
                existRent.Installments = request.Installments;
                existRent.NumberOfInstallments = request.NumberOfInstallments;

                context.Rent.Update(existRent);
                context.SaveChanges();

                return new CreateRentResponse { Rent = existRent };
            }
            else return null;
        }

        public CommonResponse DeleteRent (int id)
        {
          var RentRemove=context.Rent.FirstOrDefault(x=>x.Id==id);
            context.Rent.Remove(RentRemove); context.SaveChanges(); 

            return new CommonResponse { ObjectId=id ,Message="Successfully removed!"};
        }


    }
}
