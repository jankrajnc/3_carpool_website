using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
        {
        }

        public DbSet<CarpoolEntry> CarpoolEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings:Postgresql"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarpoolEntry>().ToTable("CarpoolEntry");
        }

    }
}