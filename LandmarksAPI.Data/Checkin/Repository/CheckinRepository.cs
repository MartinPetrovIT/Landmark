using LandmarksAPI.Data.Checkin.Entities;
using LandmarksAPI.Data.Checkin.RepositoryInterfaces;
using MongoDB.Driver;

namespace LandmarksAPI.Data.Checkin.Repository
{
    public class CheckinRepository(IMongoDatabase database) : ICheckinRepository
    {
        private readonly IMongoCollection<Entities.Checkin> checkinCollection = database.GetCollection<Entities.Checkin>("Checkins");

        public async Task<bool> HasCheckedInAfterAsync(string userId, string landmarkId, DateTime date)
        {
            // Тук създаваме "филтъра" за търсене - искаме запис, който отговаря на ТРИ условия едновременно:
            var filter = Builders<Entities.Checkin>.Filter.And(
                Builders<Entities.Checkin>.Filter.Eq(c => c.UserId, userId),         // Същият човек
                Builders<Entities.Checkin>.Filter.Eq(c => c.LandmarkId, landmarkId), // Същият връх
                Builders<Entities.Checkin>.Filter.Gte(c => c.CheckinTime, date)             // Датата да е по-голяма (Gte = Greater Than or Equal) от преди 24 часа
            );

            // Броим колко такива записа има. Ако е повече от 0, значи се е чекирал скоро!
            var count = await checkinCollection.CountDocumentsAsync(filter);
            return count > 0;
        }

        public async Task AddAsync(Entities.Checkin checkin)
        {
            // Записваме новото чекиране в базата
            await checkinCollection.InsertOneAsync(checkin);
        }

        public async Task<bool> AddPhotoAsync(string checkinId, string photoUrl)
        {
            // 1. Намираме записа по ID
            var filter = Builders<Entities.Checkin>.Filter.Eq(c => c.Id, checkinId);

            // 2. Казваме кое поле искаме да променим (Set)
            var update = Builders<Entities.Checkin>.Update.Set(c => c.PhotoUrl, photoUrl);

            // 3. Изпълняваме го
            var result = await checkinCollection.UpdateOneAsync(filter, update);

            // Ако е променило поне 1 запис, значи е успешно
            return result.ModifiedCount > 0;
        }
    }
}
