using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoliclinicaHope.Models;

namespace PoliclinicaHope.Data
{
    public class PoliclinicaHopeContext : DbContext
    {
        public PoliclinicaHopeContext (DbContextOptions<PoliclinicaHopeContext> options)
            : base(options)
        {
        }

        public DbSet<PoliclinicaHope.Models.Procedura> Procedura { get; set; } = default!;
        public DbSet<PoliclinicaHope.Models.Medic> Medic { get; set; } = default!;
    }
}
