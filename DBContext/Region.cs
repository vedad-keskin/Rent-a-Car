using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("Region")]
    public class Region
    {
        [Key]

        public int RegionID { get; set; }
        public string RegionName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
