using System.ComponentModel.DataAnnotations;

namespace PoliclinicaHope.Models
{
    public class Programare
    {
        public int ID { get; set; }

        public int? PacientId { get; set; }
        public Pacient? Pacient { get; set; }

        public int? ProceduraID { get; set; }
        public Procedura? Procedura { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Programarii")]
        public DateTime ReturnDate { get; set; }
    }
}
