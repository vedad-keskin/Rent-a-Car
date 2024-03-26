using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Region;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Region;
using RentACar.DataModels.Responses.Rent;
using RentACar.DBContext;
using RentACar.Service.Interface;

namespace RentACar.Service.Methods
{
    public class RegionService:IRegionService 
    {
        private readonly DBContext.ApplicationDbContext _dbContext =new DBContext.ApplicationDbContext();

        public List<Region> GetAllRegions ()
        {
            var response = _dbContext.Region.ToList();
            return response;
        }
       
        public CreateRegionResponse CreateNewRegion(CreateRegionRequest request)
        {
            var newRegion = new Region()
            {
                RegionName = request.RegionName,
                CountryId = request.CountryId
            };
            _dbContext.Region.Add(newRegion);
            _dbContext.SaveChanges();

            return new CreateRegionResponse() { Region = newRegion };
        }

        public CreateRegionResponse Update(UpsertRegionRequest request)
        {
            var existRegion = _dbContext.Region.FirstOrDefault(x => x.RegionID == request.RegionId);
            if (existRegion != null)
            {
                existRegion.RegionName = request.RegionName;
                existRegion.CountryId = request.CountryId;
                
                _dbContext.Region.Update(existRegion);
                _dbContext.SaveChanges();

                return new CreateRegionResponse { Region = existRegion };
            }
            else return null;
        }

        public CommonResponse DeleteRegion(int id)
        {

            var RegionRemove = _dbContext.Region.FirstOrDefault(x => x.RegionID == id);
            _dbContext.Region.Remove(RegionRemove); 
            _dbContext.SaveChanges();

            return new CommonResponse { ObjectId = id, Message = "Successfully removed!" };
        }
    }
}
