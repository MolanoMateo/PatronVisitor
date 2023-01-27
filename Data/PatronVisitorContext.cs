using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatronVisitor.Models;

namespace PatronVisitor.Data
{
    public class PatronVisitorContext : DbContext
    {
        public PatronVisitorContext (DbContextOptions<PatronVisitorContext> options)
            : base(options)
        {
        }

        public DbSet<PatronVisitor.Models.Procesador> Procesador { get; set; } = default!;

        public DbSet<PatronVisitor.Models.PlacaBase> PlacaBase { get; set; }

        public DbSet<PatronVisitor.Models.DiscoDuro> DiscoDuro { get; set; }
    }
}
