using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACar.DBContext
{
    [Table("City")]
    public class City
    {

        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string PostalNumber { get; set; }
        
        public int CountryId { get; set; }

        //posto je Country foreign key, da bi u response vratili i model Drzave, dodajemo kao property narednu liniju: 
        public virtual Country Country { get; set; }

    }
}

