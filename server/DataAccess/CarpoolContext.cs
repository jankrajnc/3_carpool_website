using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext()
        {
        }

        public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
        {
        }

        public DbSet<CarpoolEntry> CarpoolEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings:Postgresql"));
        }

    }
}