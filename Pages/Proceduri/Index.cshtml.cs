using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoliclinicaHope.Data;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Pages.Proceduri
{
    public class IndexModel : PageModel
    {
        private readonly PoliclinicaHope.Data.PoliclinicaHopeContext _context;

        public IndexModel(PoliclinicaHope.Data.PoliclinicaHopeContext context)
        {
            _context = context;
        }

        public ProceduraData ProceduraD { get; set; } = default!;
        public int ProceduraID { get; set; }
        public int DepartamentID { get; set; }

        public async Task OnGetAsync(string? searchString, string? medicName, string? departamentName)
        {
            ProceduraD = new ProceduraData();

            var proceduriQuery = _context.Procedura
                .Include(p => p.Medic)
                .Include(p => p.DepartamenteProceduri).ThenInclude(dp => dp.Departament)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                proceduriQuery = proceduriQuery.Where(p => p.Denumire.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(medicName))
            {
                proceduriQuery = proceduriQuery.Where(p => p.Medic.MedicName.Contains(medicName));
            }

            if (!string.IsNullOrEmpty(departamentName))
            {
                proceduriQuery = proceduriQuery.Where(p => p.DepartamenteProceduri
                    .Any(dp => dp.Departament.DepartamentName.Contains(departamentName)));
            }

            ProceduraD.Proceduri = await proceduriQuery
                .OrderBy(p => p.Denumire)
                .AsNoTracking()
                .ToListAsync();
        }


        public class ProceduraData
        {
            public IEnumerable<Procedura> Proceduri { get; set; } = Enumerable.Empty<Procedura>();
            public IEnumerable<Departament> Departamente { get; set; } = Enumerable.Empty<Departament>();
        }
    }
}
