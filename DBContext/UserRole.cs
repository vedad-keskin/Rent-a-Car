using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]

        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
    }
}
