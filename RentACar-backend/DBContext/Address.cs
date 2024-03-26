using System.ComponentModel.DataAnnotations;

namespace RentACar.DBContext
{
    public class Address
    {
        [Key]

        public int AddressId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int CityId { get; set; }
       public virtual City City { get; set; }
    }
}
