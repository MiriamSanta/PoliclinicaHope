using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.DepartamenteProceduri
{
    public class CreateModel : PageModel
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public CreateModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartamentId"] = new SelectList(_context.Departament, "ID", "ID");
        ViewData["ProceduraId"] = new SelectList(_context.Procedura, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public DepartamentProcedura DepartamentProcedura { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DepartamentProcedura.Add(DepartamentProcedura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
