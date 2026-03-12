namespace LandmarksAPI.Services.Landmark.ServicesInterfaces
{
    public interface ILandmarkService
    {
        Task<List<Models.Landmark>> GetAllLandmarksAsync();
        Task<Models.Landmark?> GetLandmarkByIdAsync(string id);
        Task AddLandmarkAsync(Models.Landmark landmark);
    }
}
