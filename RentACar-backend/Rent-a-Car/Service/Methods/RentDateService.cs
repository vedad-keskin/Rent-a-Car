using RentACar.DataModels.Requests.RentDate;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Region;
using RentACar.DataModels.Responses.RentDate;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class RentDateService:IRentDateService
    {
        private readonly ApplicationDbContext baza =new ApplicationDbContext();

        public List<RentDate> GetAllRentDates()
        {
            var response = baza.RentDate.ToList();
            return response;
        }

        public CreateRentDateResponse CreateNewRentDate(CreateRentDateRequest request)
        {
            var rentDate = new RentDate()
            {
                StartDate = request.StartDate,
                StartTime = request.StartDate,
                EndDate = request.EndDate,
                EndTime = request.EndDate,
                CarID=request.CarID,
                RentID=request.RentID
            };
            baza.RentDate.Add(rentDate);
            baza.SaveChanges();

            return new CreateRentDateResponse() { RentDate = rentDate };
           
        }

        public CreateRentDateResponse Update(UpsertRentDateRequest request)
        {
            var exist = baza.RentDate.FirstOrDefault(x => x.ID == request.RentDateID);
            {
                if (exist != null)
                {
                    exist.StartTime = request.StartTime;
                    exist.EndTime = request.EndTime;
                    exist.StartDate = request.StartDate;
                    exist.EndDate = request.EndDate;
                    exist.CarID = request.CarID;
                    exist.RentID = request.RentID;

                    baza.RentDate.Update(exist);
                    baza.SaveChanges();

                    return new CreateRentDateResponse() { RentDate = exist };

                }
                else return null;
            }
        }

        public CommonResponse Delete(int id)
        {
            var removeRentDate= baza.RentDate.FirstOrDefault(x=>x.ID == id);
           
                baza.RentDate.Remove(removeRentDate);
                baza.SaveChanges();
            
            return new CommonResponse() { ObjectId = id , Message="Successfully removed!"};
        }

    }
}
