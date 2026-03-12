namespace LandmarksAPI.Data.Landmark.RepositoryInterfaces
{
    public interface ILandmarkRepository
    {
        Task<List<Entities.Landmark>> GetAllAsync();

        Task<Entities.Landmark?> GetByIdAsync(string id);

        Task CreateAsync(Entities.Landmark landmark);
    }
}
