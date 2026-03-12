using LandmarksAPI.Data.Landmark.RepositoryInterfaces;
using LandmarksAPI.Services.Landmark.Mappings;
using LandmarksAPI.Services.Landmark.ServicesInterfaces;

using EntitiesModels = LandmarksAPI.Data.Landmark.Entities;

namespace LandmarksAPI.Services.Landmark.Services
{
    public class LandmarkService(ILandmarkRepository repository) : ILandmarkService
    {
        public async Task<List<Models.Landmark>> GetAllLandmarksAsync()
        {
            IEnumerable<EntitiesModels.Landmark> landmarks =
                await repository.GetAllAsync();

            List<Models.Landmark> result = landmarks.Select(LandmarkMapper.Map).ToList();

            return result;
        }

        public async Task<Models.Landmark?> GetLandmarkByIdAsync(string id)
        {
            EntitiesModels.Landmark? landmark = 
                await repository.GetByIdAsync(id);

            if (landmark == null)
                return null;

            return LandmarkMapper.Map(landmark);
        }

        public async Task AddLandmarkAsync(Models.Landmark landmark)
        {
            EntitiesModels.Landmark repoModel = LandmarkMapper.Map(landmark);

            await repository.CreateAsync(repoModel);
        }
    }
}
