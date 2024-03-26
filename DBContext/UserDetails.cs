using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("UserDetails")]
    public class UserDetails
    {
        [Key]

        public int UserDetailsId { get; set; }
        public bool Verification {  get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
