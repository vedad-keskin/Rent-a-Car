using RentACar.DataModels.Requests.CarDetails;
using RentACar.DataModels.Responses.CarDetails;
using RentACar.DataModels.Responses;
using RentACar.DBContext;
using RentACar.Service.Interface;
using RentACar.DataModels.Requests.CarImges;
using RentACar.DataModels.Responses.CarImages;

namespace RentACar.Service.Methods
{
    public class CarImagesService : ICarImagesService
    {
        private readonly ApplicationDbContext context;

        public List<CarImages> GetAll()
        {
            return context.CarImages.ToList();
        }

        public CreateCarImagesResponse CreateNewCarImages(CreateCarImagesRequest request)
        {
            foreach (var carDB in context.Car.ToList())
            {
                if (carDB.Id == request.CarId)
                {
                    var NewCarImages = new CarImages();
                    NewCarImages.CarId = request.CarId;
                    NewCarImages.ImageUrl = request.ImageUrl;


                    context.CarImages.Add(NewCarImages);
                    context.SaveChanges();
                    return new CreateCarImagesResponse() { CarImages = NewCarImages };
                }

            }
            //exception da ne postoji carId
            throw new Exception("Provided Car or Country ID does not exist.");
        }

        public CreateCarImagesResponse Update(UpsertCarImagesRequest request)
        {
            var obj = context.CarImages.FirstOrDefault(x => x.Id == request.CarImageId);

            if (obj != null)
            {
                obj.ImageUrl = request.ImageUrl;

                context.CarImages.Update(obj);
                context.SaveChanges();

                return new CreateCarImagesResponse { CarImages = obj };
            }

            else
                return null;
        }

        public CommonResponse Delete(int id)
        {
            var removeModel = context.CarImages.FirstOrDefault(x => x.Id == id);
            if (removeModel != null)
            {
                context.CarImages.Remove(removeModel);
                context.SaveChanges();
                return new CommonResponse() { Message = "Object with provided ID is successfuly deleted." };
            }

            throw new Exception("Object with provided ID is not found.");
        }
    }
}





