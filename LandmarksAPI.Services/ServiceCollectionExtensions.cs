using LandmarksAPI.Services.Checkin.Services;
using LandmarksAPI.Services.Checkin.ServicesInterfaces;
using LandmarksAPI.Services.Landmark.Services;
using LandmarksAPI.Services.Landmark.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LandmarksAPI.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLandmarkLogic(this IServiceCollection services)
        {
            services.AddTransient<ILandmarkService, LandmarkService>();
            services.AddTransient<ICheckinService, CheckinService>();

            return services;
        }
    }
}
