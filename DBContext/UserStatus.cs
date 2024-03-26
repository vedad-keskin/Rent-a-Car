using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("UserStatus")]
    public class UserStatus
    {

        [Key]
        public int UserStatusId { get; set; }
        public bool Restricted { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
