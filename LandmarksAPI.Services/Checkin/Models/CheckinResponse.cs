namespace LandmarksAPI.Services.Checkin.Models
{
    public class CheckinResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int PointsEarned { get; set; }
        public required string CheckinId { get; set; }
    }
}
