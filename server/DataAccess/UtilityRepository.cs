using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly CarpoolContext context;

        public UtilityRepository(CarpoolContext context)
        {
            this.context = context;
        }

        public async Task<string?> GetRecommendedDriverAsync()
        {
            var driver = await context.CarpoolEntry
            .GroupBy(x => x.Name)
            .Select(y => new
            {
                Name = y.Key,
                Count = y.Count()
            })
            .OrderBy(x => x.Count)
            .FirstOrDefaultAsync();

            return driver?.Name;
        }

    }
}