using Models;

namespace DataAccess
{
    public interface ICarpoolEntryRepository
    {
        Task<IEnumerable<CarpoolEntry>> GetCarpoolEntriesAsync();
        Task<CarpoolEntry> GetCarpoolEntryByIDAsync(int carpoolEntryId);
        Task InsertCarpoolEntryAsync(CarpoolEntry? carpoolEntry);
        Task DeleteCarpoolEntryAsync(int carpoolEntryId);
        Task<bool> UpdateCarpoolEntryAsync(CarpoolEntry carpoolEntry);
    }
}