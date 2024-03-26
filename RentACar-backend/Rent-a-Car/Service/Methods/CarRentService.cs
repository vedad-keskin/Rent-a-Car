using RentACar.DataModels.Requests.CarImges;
using RentACar.DataModels.Responses.CarImages;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.DataModels.Responses.CarRent;
using RentACar.DataModels.Requests.CarRent;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class CarRentService: ICarRentService
    {
        private readonly ApplicationDbContext context;

        public List<CarRent> GetAll()
        {
            return context.CarRent.ToList();
        }

        public CreateCarRentResponse CreateNewCarRent(CreateCarRentRequest request)
        {
            foreach (var carDB in context.Car.ToList())
            {
                if (carDB.Id == request.CarId)
                {
                    var NewCarRent = new CarRent();
                    NewCarRent.CarId = request.CarId;

                    context.CarRent.Add(NewCarRent);
                    context.SaveChanges();
                    return new CreateCarRentResponse() { CarRent = NewCarRent };
                }
            }
            //exception da ne postoji carId
            throw new Exception("Provided Car or Country ID does not exist.");
        }

        public CreateCarRentResponse Update(UpsertCarRentRequest request)
        {
            var obj = context.CarRent.FirstOrDefault(x => x.Id == request.CarRentId);

            if (obj != null)
            {
                obj.CarId = request.CarId;

                context.CarRent.Update(obj);
                context.SaveChanges();

                return new CreateCarRentResponse { CarRent = obj };
            }

            else
                return null;


        }

        public CommonResponse Delete(int id)
        {
            var removeModel = context.CarRent.FirstOrDefault(x => x.Id == id);
            if (removeModel != null)
            {
                context.CarRent.Remove(removeModel);
                context.SaveChanges();
                return new CommonResponse() { Message = "Object with provided ID is successfuly deleted." };
            }

            throw new Exception("Object with provided ID is not found.");


        }





    }
}
