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

        //https://learn.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-7.0
            //https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-7.0
        public async Task<IEnumerable<CarpoolEntry>> GetCarpoolEntriesAsync()
        {
            return await context.CarpoolEntry.ToListAsync();
        }

        public async Task<CarpoolEntry?> GetCarpoolEntryByIdAsync(int carpoolEntryId)
        {
            return await context.CarpoolEntry.FindAsync(carpoolEntryId);
        }

        public async Task InsertCarpoolEntryAsync(CarpoolEntry carpoolEntry)
        {
            context.CarpoolEntry.Add(carpoolEntry);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCarpoolEntryAsync(int carpoolEntryId)
        {
            CarpoolEntry? carpoolEntry = await context.CarpoolEntry.FindAsync(carpoolEntryId);

            if (carpoolEntry != null)
            {
                context.CarpoolEntry.Remove(carpoolEntry);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
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