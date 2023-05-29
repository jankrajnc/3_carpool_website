using System.Collections;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers {

    // https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&amp%3Btabs=visual-studio&tabs=visual-studio
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio#routing-and-url-paths

    // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0#create-controller-and-views
    // https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application


    // TODO
    // migration for creating the database
    // connect to db with ef
    // setup the entire framework
    // call with the controller

    // Questions
    // how to properly setup the controller, in regards to this ActionResult, Ok and Save, Dispose from context
    // how to link the context properly at startup DONE
    // how to setup a migration properly, as currently it has some issues with the DB, maybe because the startup setup has to be done before? DONE
    // maybe a general overview of how everything looks, if it's correct etc DONE

    // automapper remove X property with auto mapper, NEXT TIME.
    // map route https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-7.0

    public class CarpoolEntryController : Controller
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
            if (id < 0) { return BadRequest("Id must be a positive number."); }

            var entry =  await carpoolEntryRepository.GetCarpoolEntryByIDAsync(id);

            if(entry == null) { return NotFound(); }

            return Ok(entry);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCarpoolEntry(int id, CarpoolEntry carpoolEntry)
        {
            if (id != carpoolEntry.Id)
            {
                return BadRequest();
            }

            var updated = await carpoolEntryRepository.UpdateCarpoolEntryAsync(carpoolEntry);

            if (!updated) { return NotFound(); }

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

    }

}