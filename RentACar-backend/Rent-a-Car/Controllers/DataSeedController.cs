using Microsoft.AspNetCore.Mvc;
using RentACar.DBContext;

namespace RentACar.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataSeedController : ControllerBase
    {
        public ApplicationDbContext baza =new ApplicationDbContext();

        [HttpPost]

        public IActionResult Seed()
        {
            baza.Country.Add(new Country() { Name = "Švedska" });
            baza.Country.Add(new Country() { Name = "Japan" });
            baza.Country.Add(new Country() { Name = "Kina" });
            baza.City.Add(new City() { Name = "Goteborg", PostalNumber = "12 Frostaliden", CountryId = 1 });
            baza.City.Add(new City() { Name = "Tokyo", PostalNumber = "Opine bb ", CountryId = 1 });

            baza.Car.Add(new Car() { Model = "xc60" ,Price=50000,Mileage=23000,Used=true,Registred=true, Type="limuzina",Manufacturer="volvo",YearOfManufacture=2023});
            baza.Car.Add(new Car() { Manufacturer = "BMW", Model = "BMW X5", Price = 100000, YearOfManufacture = 2023, Mileage = 10000, Type = "SUV", Used = true, Registred = true });
            baza.Rent.Add(new Rent() { TotalAmount = 50000, TypeOfPayment = "card", Installments = true, NumberOfInstallments = 34 });

            baza.SaveChanges();
            return Ok();

            
        }





    }
}
