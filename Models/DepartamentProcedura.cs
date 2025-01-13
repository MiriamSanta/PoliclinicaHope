namespace PoliclinicaHope.Models
{
    public class DepartamentProcedura
    {
        public int ID { get; set; }

        public int ProceduraId { get; set; }

        public Procedura Procedura { get; set; }

        public int DepartamentId { get; set; }

        public Departament Departament { get; set; }
    }
}
