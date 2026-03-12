using LandmarksAPI.Services.Checkin.Models;

namespace LandmarksAPI.Checkin.Mappings
{
    public static class CheckinMapper
    {
        public static CheckinRequest Map(Models.CheckinRequest source)
        {
            CheckinRequest destination = new()
            {
                CheckinTime = source.CheckinTime,
                LandmarkId = source.LandmarkId,
                UserId = source.UserId,
                UserLatitude = source.UserLatitude,
                UserLongitude = source.UserLongitude
            };

            return destination;
        }

        public static Models.CheckinResponse Map(CheckinResponse source)
        {
            Models.CheckinResponse destination = new()
            {
                IsSuccess = source.IsSuccess,
                CheckinId = source.CheckinId,
                Message = source.Message,
                PointsEarned = source.PointsEarned,
            };

            return destination;
        }
    }
}
