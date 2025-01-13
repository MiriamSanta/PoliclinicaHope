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
    public class DetailsModel : PageModel
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public DetailsModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

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
    }
}
