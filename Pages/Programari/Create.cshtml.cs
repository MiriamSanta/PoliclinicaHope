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

namespace PoliclinicaHope.Pages.Programari
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
            var pacientList = _context.Pacient
                .Select(p => new
                {
                    p.ID,
                    PacientFullName = p.Nume 
                });

            var proceduraList = _context.Procedura
                .Include(p => p.Medic) 
                .Select(p => new
                {
                    p.ID,
                    ProceduraDetails = p.Denumire + " - Pret: " + p.Pret + " Lei"
                });

            ViewData["PacientId"] = new SelectList(pacientList, "ID", "PacientFullName");
            ViewData["ProceduraID"] = new SelectList(proceduraList, "ID", "ProceduraDetails");

            return Page();
        }



        [BindProperty]
        public Programare Programare { get; set; } = default!;

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
