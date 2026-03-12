namespace LandmarksAPI.Checkin.Models
{
    public class CheckinResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int PointsEarned { get; set; }
        public string CheckinId { get; set; } = string.Empty;
    }
}
