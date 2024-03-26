using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("CarDetails")]

    public class CarDetails
    {
        [Key]

        public int Id { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public string ChassisNumber { get; set; }

        public string Capacity { get; set; }

        public int NumberOfSeats { get; set; }

        public double CubicCapacity { get; set; }

        public double PowerKW { get; set; }

        public int CountryOfManufactureId { get; set; }
        public virtual Country CountryOfManufacture { get; set; }
    }
}