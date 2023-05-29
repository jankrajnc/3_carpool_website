namespace DataAccess
{
    public class CarpoolEntryRepository : ICarpoolEntryRepository, IDisposable
    {
        private CarpoolEntryContext context;

        public CarpoolEntryRepository(CarpoolEntryContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetCarpoolEntries()
        {
            return context.CarpoolEntries.ToList();
        }

        public Student GetCarpoolEntryByID(int carpoolEntryId)
        {
            return context.CarpoolEntries.Find(carpoolEntryId);
        }

        public void InsertCarpoolEntry(CarpoolEntry carpoolEntry)
        {
            context.CarpoolEntries.Add(carpoolEntry);
        }

        public void DeleteCarpoolEntry(int carpoolEntryId)
        {
            CarpoolEntry carpoolEntry = context.CarpoolEntries.Find(carpoolEntryId);
            context.CarpoolEntries.Remove(carpoolEntry);
        }

        public void UpdateCarpoolEntry(CarpoolEntry carpoolEntry)
        {
            context.Entry(carpoolEntry).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}