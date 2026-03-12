using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LandmarksAPI.Data.CheckIn.Entities
{
    public class Checkin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string LandmarkId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public double UserLatitude { get; set; }

        public double UserLongitude { get; set; }

        public DateTime CheckinTime { get; set; }

        public string PhotoUrl { get; set; } = string.Empty;
    }
}
