using System.ComponentModel.DataAnnotations;

namespace PoliclinicaHope.Models
{
    public class Departament
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Departament")]
        public string DepartamentName { get; set; }

        public ICollection<DepartamentProcedura>? DepartamenteProceduri { get; set; }
    }
}
