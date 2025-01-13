using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.DepartamenteProceduri
{
    public class EditModel : PageModel
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public EditModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartamentProcedura DepartamentProcedura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentprocedura =  await _context.DepartamentProcedura.FirstOrDefaultAsync(m => m.ID == id);
            if (departamentprocedura == null)
            {
                return NotFound();
            }
            DepartamentProcedura = departamentprocedura;
           ViewData["DepartamentId"] = new SelectList(_context.Departament, "ID", "ID");
           ViewData["ProceduraId"] = new SelectList(_context.Procedura, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DepartamentProcedura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentProceduraExists(DepartamentProcedura.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepartamentProceduraExists(int id)
        {
            return _context.DepartamentProcedura.Any(e => e.ID == id);
        }
    }
}
