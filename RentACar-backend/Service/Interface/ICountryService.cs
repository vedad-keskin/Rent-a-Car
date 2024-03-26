using Microsoft.AspNetCore.Mvc;
using RentACar.DataModels.Requests.Country;
using RentACar.DataModels.Responses;
using RentACar.DataModels.Responses.City;
using RentACar.DBContext;

namespace RentACar.Service.Interface
{
    public interface ICountryService
    {
        //{
        //countryName:"nazivNekeDrzave",
        //starts With ToLower()...filter
        //}
        public List<Country> GetAll();
        public CreateCountryResponse CreateNewCountry(CreateCountryRequest request);
        public CreateCountryResponse Update(UpsertCountryRequest request);
        public CommonResponse Delete(int id);
    }
}
