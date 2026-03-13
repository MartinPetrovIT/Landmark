namespace LandmarksAPI.Data.Checkin.RepositoryInterfaces
{
    public interface ICheckinRepository
    {
        Task<bool> HasCheckedInAfterAsync(string userId, string landmarkId, DateTime date);

        Task AddAsync(Entities.Checkin checkin);

        Task<bool> AddPhotoAsync(string checkinId, string photoUrl);
    }
}
