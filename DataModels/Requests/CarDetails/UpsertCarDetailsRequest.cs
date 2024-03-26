﻿namespace RentACar.DataModels.Requests.CarDetails
{
    public class UpsertCarDetailsRequest
    {
        public int CarDetailId {  get; set; }  
        public int CarId { get; set; }
        public string ChassisNumber { get; set; }
        public string Capacity { get; set; }
        public int NumberOfSeats { get; set; }
        public double CubicCapacity { get; set; }
        public double PowerKW { get; set; }
        public int CountryOfManufacturerId { get; set; }  
    }
}
