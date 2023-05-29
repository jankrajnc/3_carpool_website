using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext()
        {
        }

        public DbSet<CarpoolEntry> CarpoolEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings:Postgresql"));
        }

    }
}