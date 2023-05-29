namespace DataAccess
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext()
        {
        }

        public DbSet<CarpoolEntry> CarpoolEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarpoolEntry>().ToTable("CarpoolEntry");
        }

    }
}