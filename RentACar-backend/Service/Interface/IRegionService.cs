using RentACar.DataModels.Requests.Region;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.Region;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface IRegionService
    {
        public List<Region> GetAllRegions();
        public CreateRegionResponse CreateNewRegion(CreateRegionRequest request);
        public CreateRegionResponse Update(UpsertRegionRequest request);

        public CommonResponse DeleteRegion(int id);
    }
}
