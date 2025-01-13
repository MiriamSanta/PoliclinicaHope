namespace PoliclinicaHope.Models
{
    public class ProceduraData
    {
        public IEnumerable<Procedura> Proceduri { get; set; }
        public IEnumerable<Departament> Departamente { get; set; }
        public IEnumerable<DepartamentProcedura> DepartamenteProceduri { get; set; }
    }
}
