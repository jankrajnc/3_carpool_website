using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers {

    // https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&amp%3Btabs=visual-studio&tabs=visual-studio
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio#routing-and-url-paths

    // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0#create-controller-and-views
    // https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

    // automapper remove X property with auto mapper, NEXT TIME.
    // map route https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-7.0

    // logging?
    // security?

    [ApiController]
    [Route("[carpool-entry]")]
    public class CarpoolEntryController : ControllerBase
    {
        private readonly ICarpoolEntryRepository carpoolEntryRepository;

        public CarpoolEntryController()
        {
            this.carpoolEntryRepository = new CarpoolEntryRepository(new CarpoolContext());
        }

        public CarpoolEntryController(ICarpoolEntryRepository carpoolEntryRepository)
        {
            this.carpoolEntryRepository = carpoolEntryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarpoolEntries()
        {
            var entries = await carpoolEntryRepository.GetCarpoolEntriesAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarpoolEntry(int id)
        {
            if (id < 0) 
            { 
                return BadRequest("Id must be a positive number."); 
            }

            var entry =  await carpoolEntryRepository.GetCarpoolEntryByIDAsync(id);

            if(entry == null) 
            { 
                return NotFound(); 
            }

            return Ok(entry);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertCarpoolEntry(CarpoolEntry carpoolEntry)
        {
            await carpoolEntryRepository.InsertCarpoolEntryAsync(carpoolEntry);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCarpoolEntry(int id, CarpoolEntry carpoolEntry)
        {
            if (id != carpoolEntry.Id)
            {
                return BadRequest();
            }

            var updated = await carpoolEntryRepository.UpdateCarpoolEntryAsync(carpoolEntry);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCarpoolEntry(int id)
        {
            if (id < 0) 
            { 
                return BadRequest("Id must be a positive number.");
            }

            var deleted = await carpoolEntryRepository.DeleteCarpoolEntryAsync(id);

            if (!deleted) 
            { 
                return NotFound(); 
            }

            return NoContent();
        }

    }

}