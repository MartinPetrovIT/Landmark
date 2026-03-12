using LandmarksAPI.Services.Checkin.Models;
using LandmarksAPI.Services.Checkin.ServicesInterfaces;

namespace LandmarksAPI.Services.Checkin.Services
{
    public class CheckinService : ICheckinService
    {
        public Task<CheckinResponse> ProcessCheckinAsync(CheckinRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
