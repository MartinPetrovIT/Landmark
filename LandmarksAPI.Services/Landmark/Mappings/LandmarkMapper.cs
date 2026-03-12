using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesModels = LandmarksAPI.Data.Landmark.Entities;

namespace LandmarksAPI.Services.Landmark.Mappings
{
    internal static class LandmarkMapper
    {
        public static Models.Landmark Map(EntitiesModels.Landmark source)
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

        public static EntitiesModels.Landmark Map(Models.Landmark source)
        {
            ArgumentNullException.ThrowIfNull(source);

            EntitiesModels.Landmark destination = new()
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
