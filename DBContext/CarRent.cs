using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("CarRent")]

    public class CarRent
    {
        [Key]

        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
