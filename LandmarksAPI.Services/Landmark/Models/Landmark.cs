namespace LandmarksAPI.Services.Landmark.Models
{

    public class Landmark
    {
        public string Id { get; set; } = string.Empty;

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }

        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        public required string Category { get; set; }

        public required string Country { get; set; }

        public required string City { get; set; }
    }
}
