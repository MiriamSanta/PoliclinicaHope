using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.DepartamenteProceduri
{
    public class DeleteModel : PageModel
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public DeleteModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
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

            var departamentprocedura = await _context.DepartamentProcedura.FirstOrDefaultAsync(m => m.ID == id);

            if (departamentprocedura == null)
            {
                return NotFound();
            }
            else
            {
                DepartamentProcedura = departamentprocedura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentprocedura = await _context.DepartamentProcedura.FindAsync(id);
            if (departamentprocedura != null)
            {
                DepartamentProcedura = departamentprocedura;
                _context.DepartamentProcedura.Remove(DepartamentProcedura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
