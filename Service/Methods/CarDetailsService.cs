using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class CarDetailsService : ICarDetailsService
    {
        private readonly DbSetContext context = new DbSetContext();

        public List<CarDetails> GetAll()
        {
            return context.CarDetails.ToList();
        }

        public CreateCarDetailsResponse CreateNewCarDetails(CreateCarDetailsRequest request)
        {
            //provjera da li vec postoji CarId koji zelimo da dodijelimo CarDetailsu
            foreach (var carDB in context.Car.ToList())
            {
                if (carDB.Id == request.CarId)
                {
                    foreach (var countryDB in context.Country.ToList())
                    {
                        if (countryDB.CountryId == request.CountryOfManufactureId)
                        {
                            var NewCarDetails = new CarDetails();
                            NewCarDetails.CarId = request.CarId;
                            NewCarDetails.Capacity = request.Capacity;
                            NewCarDetails.CubicCapacity = request.CubicCapacity;
                            NewCarDetails.NumberOfSeats = request.NumberOfSeats;
                            NewCarDetails.CountryOfManufactureId = request.CountryOfManufactureId;
                            NewCarDetails.PowerKW = request.PowerKW;
                            NewCarDetails.ChassisNumber = request.ChassisNumber;

                            context.CarDetails.Add(NewCarDetails);
                            context.SaveChanges();
                            return new CreateCarDetailsResponse() { CarDetails = NewCarDetails };
                        }
                    }
                }

            }
                //exception da ne postoji carId
                throw new Exception("Provided Car or Country ID does not exist.");
        }

            public CreateCarDetailsResponse Update(UpsertCarDetailsRequest request)
        {
            var obj = context.CarDetails.FirstOrDefault(x => x.Id == request.CarDetailId);

            if (obj != null)
            {
                var countryObj = context.Country.FirstOrDefault(x => x.CountryId == request.CountryOfManufacturerId);
                if(countryObj != null)
                {
                obj.PowerKW = request.PowerKW;
                obj.CubicCapacity = request.CubicCapacity;
                obj.Capacity = request.Capacity;
                obj.CountryOfManufactureId = request.CountryOfManufacturerId;
                obj.ChassisNumber = request.ChassisNumber;
                obj.NumberOfSeats = request.NumberOfSeats;

                context.CarDetails.Update(obj);
                context.SaveChanges();

                }

                return new CreateCarDetailsResponse { CarDetails = obj };

            }
            else
                return null;                

        }

        public CommonResponse Delete(int id)
        {
            var removeModel = context.CarDetails.FirstOrDefault(x => x.Id == id);
            if (removeModel != null)
            {
                context.CarDetails.Remove(removeModel);
                context.SaveChanges();
                return new CommonResponse() { Message = "Object with provided ID is successfuly deleted." };
            }


            throw new Exception("Object with provided ID is not found.");
        }

    }
}
