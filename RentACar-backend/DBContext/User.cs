using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName  { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }



    }
}
