using LandmarksAPI.Services.Checkin.Models;

namespace LandmarksAPI.Services.Checkin.ServicesInterfaces
{
    public interface ICheckinService
    {
        Task<CheckinResponse> ProcessCheckinAsync(CheckinRequest request);
    }
}
