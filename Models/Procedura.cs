
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace PoliclinicaHope.Models
{
    public class Procedura
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Procedura")]
        public string Denumire { get; set; }
        public string? Descriere { get; set; }
        public int Pret { get; set; }
        public int? MedicId { get; set; }
        public Medic? Medic { get; set; }

        public ICollection<Programare>? Programari { get; set; }

        public ICollection<DepartamentProcedura>? DepartamenteProceduri { get; set; }

    }
}