using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }    
        public DateTime BirthDate { get; set; }

    }
}
