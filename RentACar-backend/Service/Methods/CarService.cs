using RentACar.DataModels.Requests.Car;
using RentACar.DataModels.Requests.City;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Car;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DataModels.Responses.City;
using RentACar.DBContext;
using RentACar.Service.Interface;
using System.Runtime.CompilerServices;

namespace RentACar.Service.Methods
{
    public class CarService: ICarService
    {
        private readonly DbSetContext context=new DbSetContext();

        public List<Car> GetAll()
        {
            return context.Car.ToList();
        }

        public CreateCarResponse CreateNewCar(CreateCarRequest request)
        {
            var newCar = new Car()
            {
                Manufacturer=request.Manufacturer,
                Model=request.Model,
                Price  =request.Price,  
                YearOfManufacture = request.YearOfManufacture,  
                Mileage= request.Mileage,    
                Type  = request.Type,   
                Used=request.Used,  
                Registred=request.Registred
            };

            context.Car.Add(newCar);
            context.SaveChanges();

            return new CreateCarResponse
            {
                Car = newCar
            };
        }

        public CreateCarResponse Update (UpsertCarRequest request) {

            var obj = context.Car.FirstOrDefault(x => x.Id == request.CarId);

            if (obj != null)
            {
                    obj.Manufacturer = request.Manufacturer;
                    obj.YearOfManufacture = request.YearOfManufacture;
                    obj.Model = request.CarModel;
                    obj.Price = request.Price;
                    obj.Mileage = request.Mileage;
                    obj.Type = request.Type;
                    obj.Used = request.Used;
                    obj.Registred = request.Registred;
                  
                context.Car.Update(obj);
                context.SaveChanges();
               
                return new CreateCarResponse { Car = obj };
             }

            else
                return null;
        }  

        public CommonResponse Delete (int id)
        {
            var carRemove = context.Car.FirstOrDefault(c=>c.Id==id);

            if (carRemove!=null) { 
            context.Car.Remove(carRemove);
              context.SaveChanges();
                return new CommonResponse() { ObjectId = id, Message = "Sucessfully removed!" };
           }
            else
            {
                return new CommonResponse() { ObjectId = id, Message = "Car with provided id does not exist!" };
            }

        }






    }
}
