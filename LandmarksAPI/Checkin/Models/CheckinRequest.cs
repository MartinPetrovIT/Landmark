namespace LandmarksAPI.Checkin.Models
{

    public class CheckinRequest
    {
        public string LandmarkId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public double UserLatitude { get; set; }

        public double UserLongitude { get; set; }

        public DateTime CheckinTime { get; set; }
    }
}
