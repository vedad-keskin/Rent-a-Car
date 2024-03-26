using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACar.DBContext
{ 
     [Table("Car")]

    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int YearOfManufacture { get; set; }

        public double Mileage { get; set; }

        public string Type { get; set; }

        public bool Used { get; set; }

        public bool Registred { get; set; }

        [JsonIgnore]
        public virtual ICollection<CarDetails> CarDetails { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<CarImages> CarImages { get; set; }

        [JsonIgnore]

        public virtual ICollection<RentDate> RentDate { get; set; }

        

    }
}
