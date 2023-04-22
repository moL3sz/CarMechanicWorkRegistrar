using Microsoft.EntityFrameworkCore;
using WorkRegistrarAPI.Models;

namespace WorkRegistrarAPI.Data
{
    public class PitStopContext : DbContext
    {
        public PitStopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Workflow> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workflow>().Property(t => t.WorkCatagory).HasConversion<int>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
