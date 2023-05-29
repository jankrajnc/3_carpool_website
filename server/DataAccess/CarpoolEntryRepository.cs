using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class CarpoolEntryRepository : ICarpoolEntryRepository
    {
        private readonly CarpoolContext context;

        public CarpoolEntryRepository(CarpoolContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CarpoolEntry>> GetCarpoolEntriesAsync()
        {
            return await context.CarpoolEntries.ToListAsync();
        }

        public async Task<CarpoolEntry?> GetCarpoolEntryByIDAsync(int carpoolEntryId)
        {
            return await context.CarpoolEntries.FindAsync(carpoolEntryId);
        }

        public async Task InsertCarpoolEntryAsync(CarpoolEntry carpoolEntry)
        {
            context.CarpoolEntries.Add(carpoolEntry);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCarpoolEntryAsync(int carpoolEntryId)
        {
            CarpoolEntry? carpoolEntry = await context.CarpoolEntries.FindAsync(carpoolEntryId);

            if (carpoolEntry != null)
            {
                context.CarpoolEntries.Remove(carpoolEntry);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateCarpoolEntryAsync(CarpoolEntry carpoolEntry)
        {
            context.Entry(carpoolEntry).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            if(result == 0)
            {
                return false;
            }

            return true;
        }

    }
}