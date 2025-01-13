using System.ComponentModel.DataAnnotations;

namespace PoliclinicaHope.Models
{
    public class Pacient
    {
        public int ID { get; set; }

        public string? Nume { get; set; }

        public string? Adresa { get; set; }

        public string Email { get; set; }

        public string? Telefon { get; set; }

        public ICollection<Programare>? Programari { get; set; }
    }
}
