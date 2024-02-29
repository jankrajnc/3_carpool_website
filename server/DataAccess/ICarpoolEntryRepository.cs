using Models;

namespace DataAccess
{
    public interface ICarpoolEntryRepository
    {
        Task<IEnumerable<CarpoolEntry>> GetCarpoolEntriesAsync();
        Task<CarpoolEntry> GetCarpoolEntryByIdAsync(int carpoolEntryId);
        Task InsertCarpoolEntryAsync(CarpoolEntry? carpoolEntry);
        Task<bool> DeleteCarpoolEntryAsync(int carpoolEntryId);
        Task<bool> UpdateCarpoolEntryAsync(CarpoolEntry carpoolEntry);
    }
}