using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.Proceduri
{
    public class EditModel : PopulareApartenentaDepartament
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public EditModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Procedura Procedura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procedura = await _context.Procedura
                .Include(p => p.Medic)
                .Include(p => p.DepartamenteProceduri).ThenInclude(dp => dp.Departament)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Procedura == null)
            {
                return NotFound();
            }

            PopulateApartenentaDepartament(_context, Procedura);

            ViewData["MedicId"] = new SelectList(_context.Medic, "ID", "MedicName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDepartamente)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proceduraToUpdate = await _context.Procedura
                .Include(p => p.Medic)
                .Include(p => p.DepartamenteProceduri).ThenInclude(dp => dp.Departament)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (proceduraToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Procedura>(
                proceduraToUpdate,
                "Procedura",
                p => p.Denumire,
                p => p.Descriere,
                p => p.Pret,
                p => p.MedicId))


            {
                UpdateDepartamenteProceduri(_context, selectedDepartamente, proceduraToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateDepartamenteProceduri(_context, selectedDepartamente, proceduraToUpdate);
            PopulateApartenentaDepartament(_context, proceduraToUpdate);
            return Page();

         
        }

    }
}
