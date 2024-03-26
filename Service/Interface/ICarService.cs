using Microsoft.EntityFrameworkCore;
using RentACar.DataModels.Requests.Car;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Car;
using RentACar.DBContext;
using System.Data.Common;
using System.Security.AccessControl;

namespace RentACar.Service.Interface
{
    public interface ICarService
    { 
        public List <Car> GetAll();
        public CreateCarResponse CreateNewCar(CreateCarRequest request);
        public  CreateCarResponse Update(UpsertCarRequest request);
        public CommonResponse Delete(int id);
    }
}
