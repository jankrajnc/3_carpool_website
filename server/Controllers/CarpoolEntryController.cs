using System.Collections;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers {

    // https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&amp%3Btabs=visual-studio&tabs=visual-studio
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio#routing-and-url-paths

    // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0#create-controller-and-views
    // https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

    [Route("api/CarpoolEntry")]
    [ApiController]
    public class CarpoolEntryController : ControllerBase

                private readonly CarpoolEntryContext _context;

    public CarpoolEntryController(CarpoolEntryContext context)
    {
        _context = context;
    }


    {
        PostgresConnector connector = new PostgresConnector();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var collection = connector.CarpoolEntry.ToList();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private static List<CarpoolEntry> _entries = new List<CarpoolEntry>()
       {
         new CarpoolEntry{ Id=1, Date="2023-03-28T00:00:00.000Z", Name="Jan" },
         new CarpoolEntry{ Id=2, Date="2023-04-01T00:00:00.000Z", Name="Gregor"},
         new CarpoolEntry{ Id=3, Date="2023-04-15T00:00:00.000Z", Name="Martin"}
       };

        [HttpGet("")]
        public async Task<ActionResult<CarpoolEntry>> GetCarpoolEntries()
        {
            return _entries;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarpoolEntry>> CreateCarpoolEntry(int id)
        {
            var entry = await _entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarpoolEntry(int id, CarpoolEntry carpoolEntry)
        {
            if (id != carpoolEntry.Id)
            {
                return BadRequest();
            }

            try
            {
                await _entries.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarpoolEntry(int id)
        {
            var entry = await _entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _entries.Remove(entry);
            await _entries.SaveChangesAsync();

            return NoContent();
        }

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