using System.ComponentModel.DataAnnotations;

namespace PoliclinicaHope.Models
{
    public class Medic
    {
        public int ID { get; set; }
        [Display(Name = "Nume Medic")]
        public required string MedicName { get; set; }
        public ICollection<Procedura>? Proceduri { get; set; }
    }
}
