using Microsoft.EntityFrameworkCore;
using SIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Infrastructure.Persistence.Context
{
    public class SIIMSDbContext : DbContext
    {
        public SIIMSDbContext(DbContextOptions<SIIMSDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Tickets table representation.
        /// </summary>
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SIIMSDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
