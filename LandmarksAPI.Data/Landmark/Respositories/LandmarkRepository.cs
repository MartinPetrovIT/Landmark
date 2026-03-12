using LandmarksAPI.Data.Landmark.Constants;
using LandmarksAPI.Data.Landmark.RepositoryInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarksAPI.Data.Landmark.Respositories
{
    public class LandmarkRepository(IMongoDatabase database) : ILandmarkRepository
    {
        private readonly IMongoCollection<Entities.Landmark> landmarks = database.GetCollection<Entities.Landmark>(LandmarkConstants.LENDMARKS);

        public async Task<List<Entities.Landmark>> GetAllAsync() =>
            await landmarks.Find(_ => true).ToListAsync();

        public async Task<Entities.Landmark?> GetByIdAsync(string id) =>
            await landmarks.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Entities.Landmark landmark) =>
            await landmarks.InsertOneAsync(landmark);
    }
}
