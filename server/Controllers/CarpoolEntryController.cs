using DataAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers {

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("OpenCorsPolicy")]
    public class CarpoolEntryController : ControllerBase
    {
        private readonly ICarpoolEntryRepository carpoolEntryRepository;

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
            if (id != carpoolEntry.ID)
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