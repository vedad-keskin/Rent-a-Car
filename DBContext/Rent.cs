using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RentACar.DBContext
{
    [Table("Rent")]
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public string TypeOfPayment { get; set; }
        public bool Installments { get; set; }
        public int NumberOfInstallments {  get; set; }

        [JsonIgnore]

        public virtual ICollection<RentDate> Dates { get; set; }
       
    }
}
