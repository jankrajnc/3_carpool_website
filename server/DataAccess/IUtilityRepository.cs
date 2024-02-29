namespace DataAccess
{
    public interface IUtilityRepository
    {
        Task<string?> GetRecommendedDriverAsync();
    }
}