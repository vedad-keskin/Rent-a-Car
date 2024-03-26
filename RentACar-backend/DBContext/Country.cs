using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACar.DBContext
{
    [Table("Country")]
    public class Country
    {
        [Key]

        public int CountryId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set;}
        [JsonIgnore]

        public virtual ICollection<Region> Regions { get; set;}




    }
}
