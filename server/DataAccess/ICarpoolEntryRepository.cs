namespace DataAccess
{
    public interface ICarpoolEntryRepository : IDisposable
    {
        IEnumerable<CarpoolEntry> GetCarpoolEntries();
        CarpoolEntry GetCarpoolEntryByID(int carpoolEntryId);
        void InsertCarpoolEntry(CarpoolEntry carpoolEntry);
        void DeleteCarpoolEntry(int carpoolEntryId);
        void UpdateCarpoolEntry(CarpoolEntry carpoolEntry);
        void Save();
    }
}