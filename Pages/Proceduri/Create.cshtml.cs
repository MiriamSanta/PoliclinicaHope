using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.Proceduri
{
    public class CreateModel : PopulareApartenentaDepartament
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public CreateModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MedicId"] = new SelectList(_context.Medic, "ID", "MedicName");

            var procedura = new Procedura();
            procedura.DepartamenteProceduri = new List<DepartamentProcedura>();

            PopulateApartenentaDepartament(_context, procedura);

            return Page();
        }

        [BindProperty]
        public Procedura Procedura { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedDepartamente)
        {
            var newProcedura = new Procedura();

            if (selectedDepartamente != null)
            {
                newProcedura.DepartamenteProceduri = new List<DepartamentProcedura>();
                foreach (var departament in selectedDepartamente)
                {
                    var departamentToAdd = new DepartamentProcedura
                    {
                        DepartamentId = int.Parse(departament)
                    };
                    newProcedura.DepartamenteProceduri.Add(departamentToAdd);
                }
            }

            Procedura.DepartamenteProceduri = newProcedura.DepartamenteProceduri;

            if (!ModelState.IsValid)
            {
                PopulareApartenentaDepartament(_context, Procedura);
                return Page();
            }

            _context.Procedura.Add(Procedura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void PopulareApartenentaDepartament(PoliclinicaHopeContext context, Procedura procedura)
        {
            throw new NotImplementedException();
        }
    }
}
