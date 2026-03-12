namespace LandmarksAPI.Landmark.Mappings
{
    internal class LandmarkMapper
    {
        public static Models.Landmark Map(Services.Landmark.Models.Landmark source)
        {
            ArgumentNullException.ThrowIfNull(source);

            Models.Landmark destination = new()
            {
                Id = source.Id,
                Category = source.Category,
                City = source.City,
                Country = source.Country,
                Description = source.Description,
                ImageUrl = source.ImageUrl,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
                Name = source.Name,
            };

            return destination;
        }

        public static Services.Landmark.Models.Landmark Map(Models.Landmark source)
        {
            ArgumentNullException.ThrowIfNull(source);

            Services.Landmark.Models.Landmark destination = new()
            {
                Id = source.Id,
                Category = source.Category,
                City = source.City,
                Country = source.Country,
                Description = source.Description,
                ImageUrl = source.ImageUrl,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
                Name = source.Name,
            };

            return destination;
        }
    }
}
