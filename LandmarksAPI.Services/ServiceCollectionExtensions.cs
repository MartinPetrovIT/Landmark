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

            return services;
        }
    }
}
