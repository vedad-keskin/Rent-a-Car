using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("RentDate")]
    public class RentDate
    {
        [Key]
        public int ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
        public int RentID { get; set; }
        public virtual Rent Rent { get; set; }

    }
}
