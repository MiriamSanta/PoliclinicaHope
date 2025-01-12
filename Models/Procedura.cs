using System.Security.Policy;

namespace PoliclinicaHope.Models
{
    public class Procedura
    {
        public int ID { get; set; }
        public required string Denumire { get; set; }
        public string? Descriere { get; set; }
        public int Pret { get; set; }
        public int? MedicId { get; set; }
        public Medic? Medic { get; set; }

    }
}