using LandmarksAPI.Data.Checkin.Repository;
using LandmarksAPI.Data.Checkin.RepositoryInterfaces;
using LandmarksAPI.Data.Landmark.RepositoryInterfaces;
using LandmarksAPI.Data.Landmark.Respositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace LandmarksAPI.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLandmarksRepository(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetValue<string>("MongoDbSettings:ConnectionString");
            var databaseName = config.GetValue<string>("MongoDbSettings:DatabaseName");

            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(databaseName);
            });

            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            services.AddScoped<ICheckinRepository, CheckinRepository>();

            return services;
        }
    }
}
