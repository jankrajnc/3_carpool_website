using System.Collections;
using Models;

namespace Database { 

    public class CarpoolEntryController
    {

        private static List<CarpoolEntry> _entries = new List<CarpoolEntry>()
       {
         new CarpoolEntry{ Id=1, Date="2023-03-28T00:00:00.000Z", Name="Jan" },
         new CarpoolEntry{ Id=2, Date="2023-04-01T00:00:00.000Z", Name="Gregor"},
         new CarpoolEntry{ Id=3, Date="2023-04-15T00:00:00.000Z", Name="Martin"}
       };

        public static List<CarpoolEntry> GetCarpoolEntries()
        {
            return _entries;
        }

        public static CarpoolEntry? GetCarpoolEntry(int id)
        {
            return _entries.SingleOrDefault(element => element.Id == id);
        }

        public static CarpoolEntry CreateCarpoolEntry(CarpoolEntry entry)
        {
            _entries.Add(entry);
            return entry;
        }

        public static CarpoolEntry UpdateCarpoolEntry(CarpoolEntry entry)
        {
            _entries = _entries.Select(element =>
            {
                if (element.Id == entry.Id)
                {
                    element.Name = entry.Name;
                }
                return element;
            }).ToList();
            return entry;
        }

        public static void RemoveCarpoolEntry(int id)
        {
            _entries = _entries.FindAll(element => element.Id != id).ToList();
        }
    }

}