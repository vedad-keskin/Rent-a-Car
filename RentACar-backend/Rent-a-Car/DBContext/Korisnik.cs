using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.DBContext
{
    [Table("Korisnik")]
    public class Korisnik : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
