using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityRepository utilityRepository;
        private readonly IMemoryCache _memoryCache;

        public UtilityController(IUtilityRepository utilityRepository, IMemoryCache _memoryCache)
        {
            this.utilityRepository = utilityRepository;
            this._memoryCache = _memoryCache;
        }

        [HttpGet("RecommendedDriver")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecommendedDriver()
        {
            const string cacheKey = "recommended_driver";
            if (!_memoryCache.TryGetValue(cacheKey, out DateTime cacheValue))
            {
                var recommendedDriver = await utilityRepository.GetRecommendedDriverAsync();
                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(12));
                _memoryCache.Set(cacheKey, recommendedDriver, cacheOptions);
            }

            return Ok(_memoryCache.Get(cacheKey));
        }

    }

}