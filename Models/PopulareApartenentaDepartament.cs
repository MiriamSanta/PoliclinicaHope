using Microsoft.AspNetCore.Mvc.RazorPages;
using PoliclinicaHope.Data;

namespace PoliclinicaHope.Models
{
    public class PopulareApartenentaDepartament : PageModel
    {
        public List<DepartamentAsociat> DepartamentAsociatDataList;

        public void PopulateApartenentaDepartament(PoliclinicaHopeContext context,
                                                   Procedura procedura)
        {
            var allDepartamente = context.Departament;
            var DepartamenteProceduri = new HashSet<int>(
                procedura.DepartamenteProceduri.Select(c => c.DepartamentId)); //
            DepartamentAsociatDataList = new List<DepartamentAsociat>();
            foreach (var cat in allDepartamente)
            {
                DepartamentAsociatDataList.Add(new DepartamentAsociat
                {
                    DepartamentId = cat.ID,
                    Nume = cat.DepartamentName,
                    Apartenenta = DepartamenteProceduri.Contains(cat.ID)
                });
            }
        }

        public void UpdateDepartamenteProceduri(PoliclinicaHopeContext context,
            string[] selectedDepartamente, Procedura proceduraToUpdate)
        {
            if (selectedDepartamente == null)
            {
                proceduraToUpdate.DepartamenteProceduri = new List<DepartamentProcedura>();
                return;
            }

            var selectedDepartamenteHS = new HashSet<string>(selectedDepartamente);
            var DepartamenteProceduri = new HashSet<int>(
                proceduraToUpdate.DepartamenteProceduri.Select(c => c.Departament.ID));
            foreach (var cat in context.Departament)
            {
                if (selectedDepartamenteHS.Contains(cat.ID.ToString()))
                {
                    if (!DepartamenteProceduri.Contains(cat.ID))
                    {
                        proceduraToUpdate.DepartamenteProceduri.Add(
                            new DepartamentProcedura
                            {
                                ProceduraId = proceduraToUpdate.ID,
                                DepartamentId = cat.ID
                            });
                    }
                }
                else
                {
                    if (DepartamenteProceduri.Contains(cat.ID))
                    {
                        DepartamentProcedura departamentToRemove
                            = proceduraToUpdate
                                .DepartamenteProceduri
                                .SingleOrDefault(i => i.DepartamentId == cat.ID);
                        context.Remove(departamentToRemove);
                    }
                }
            }
        }
    }
}
