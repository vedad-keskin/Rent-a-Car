using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace RentACar.DBContext
{
    [Table("CarImages")]

    public class CarImages
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
