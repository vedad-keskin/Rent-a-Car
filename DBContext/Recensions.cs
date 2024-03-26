using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("Recensions")]

    public class Recensions
    {
        [Key]
        public int RecensionsId { get; set; }
        public int StarRating { get; set; }
        public string Messages { get; set; }

    }
}
