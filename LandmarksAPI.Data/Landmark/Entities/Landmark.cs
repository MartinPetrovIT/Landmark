using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LandmarksAPI.Data.Landmark.Entities
{
    public class Landmark
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Category { get; set; } = string.Empty;

        // --- НОВИТЕ ПОЛЕТА ---

        // Държава (по подразбиране може да е празно, но когато създаваме обекти ще слагаме "България")
        public string Country { get; set; } = string.Empty;

        // Град или най-близко населено място (напр. "София", "Банско")
        public string Region { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int CheckinPoints { get; set; }
    }
}