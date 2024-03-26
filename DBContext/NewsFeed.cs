using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("NewsFeed")]
    public class NewsFeed
    {
        [Key]

        public int NewsId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }

    }
}
