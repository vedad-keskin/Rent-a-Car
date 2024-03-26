using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("Transactions")]
    public class Transactions
    {
        [Key]
        public int TransactinId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
