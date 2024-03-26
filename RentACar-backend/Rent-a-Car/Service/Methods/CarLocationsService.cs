using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.DataModels.Responses.CarLocations;
using RentACar.DataModels.Requests.CarLocations;

namespace RentACar.Service.Methods
{
    public class CarLocationsService : ICarLocationsService
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public List<CarLocations> GetAll()
        {
            return context.CarLocations.ToList();
        }

        public CreateCarLocationsResponse CreateNewCarLocations(CreateCarLocationsRequest request)
        {

            foreach (var carDB in context.Car.ToList())
            {
                if (carDB.Id == request.CarId)
                {
                    var NewCarLocations = new CarLocations();
                    NewCarLocations.CarId = request.CarId;
                    NewCarLocations.LocationID = request.LocationId;
                    NewCarLocations.CityId = request.CityId;


                    context.CarLocations.Add(NewCarLocations);
                    context.SaveChanges();
                    return new CreateCarLocationsResponse() { CarLocations = NewCarLocations };

                }

            }
            //exception da ne postoji carId
            throw new Exception("Provided Car does not exist.");
        }

        public CreateCarLocationsResponse Update(UpsertCarLocationsRequest request)
        {
            var obj = context.CarLocations.FirstOrDefault(x => x.Id == request.CarLocationsId);

            if (obj != null)
            {

                obj.LocationID = request.LocationId;
                obj.CarId = request.CarId;
                obj.CityId = request.CityId;


                context.CarLocations.Update(obj);
                context.SaveChanges();

                return new CreateCarLocationsResponse { CarLocations = obj };

            }
            else
                return null;

        }

        public CommonResponse Delete(int id)
        {
            var removeModel = context.CarLocations.FirstOrDefault(x => x.Id == id);
            if (removeModel != null)
            {
                context.CarLocations.Remove(removeModel);
                context.SaveChanges();
                return new CommonResponse() { Message = "Object with provided ID is successfuly deleted." };
            }


            throw new Exception("Object with provided ID is not found.");
        }
    }
}
