using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace RentACar.DBContext
{
    [Table("CarLocations")]
    public class CarLocations
    {
        [Key]
        public int Id { get; set; } 
        public int LocationID { get; set; }
        public int  CarId { get; set; }
        public int CityId { get; set; }


    }
}
