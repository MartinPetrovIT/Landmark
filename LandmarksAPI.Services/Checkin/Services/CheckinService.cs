using LandmarksAPI.Data.Checkin.RepositoryInterfaces;
using LandmarksAPI.Data.Landmark.RepositoryInterfaces;
using LandmarksAPI.Services.Checkin.Models;
using LandmarksAPI.Services.Checkin.ServicesInterfaces;

namespace LandmarksAPI.Services.Checkin.Services
{
    public class CheckinService(
            ICheckinRepository checkinRepo,
            ILandmarkRepository landmarkRepo) : ICheckinService
    {
        private const double MaxDistanceMeters = 500;

        public async Task<CheckinResponse> ProcessCheckinAsync(CheckinRequest request)
        {
            var landmark = await landmarkRepo.GetByIdAsync(request.LandmarkId);

            if (landmark == null)
            {
                return new CheckinResponse { IsSuccess = false, Message = "Обектът не е намерен!" };
            }

            double distance = CalculateDistance(
                request.UserLatitude, request.UserLongitude,
                landmark.Latitude, landmark.Longitude);

            if (distance > MaxDistanceMeters)
            {
                // Потребителят е твърде далеч
                return new CheckinResponse
                {
                    IsSuccess = false,
                    Message = $"Твърде сте далеч! Намирате се на {Math.Round(distance)} метра от обекта. Трябва да сте на максимум {MaxDistanceMeters}м."
                };
            }

            // 3. ПРОВЕРКА ЗА СПАМ (24 часа Cooldown)
            // Искаме да видим дали има чекиране през последните 24 часа
            var cooldownTime = DateTime.UtcNow.AddHours(-24);
            bool hasRecentCheckin = await checkinRepo.HasCheckedInAfterAsync(request.UserId, request.LandmarkId, cooldownTime);

            if (hasRecentCheckin)
            {
                return new CheckinResponse
                {
                    IsSuccess = false,
                    Message = "Вече сте се чекирали тук през последните 24 часа. Опитайте отново утре!"
                };
            }

            // 4. ВСИЧКО Е ТОЧНО -> ЗАПИСВАМЕ В БАЗАТА
            var newCheckin = new Data.Checkin.Entities.Checkin
            {
                UserId = request.UserId,
                LandmarkId = request.LandmarkId,
                CheckinTime = request.CheckinTime, // Ползваме часа от телефона, защото може да е бил офлайн!
                PointsEarned = landmark.CheckinPoints
            };

            await checkinRepo.AddAsync(newCheckin);

            return new CheckinResponse
            {
                IsSuccess = true,
                Message = "Успешно чекиране!",
                PointsEarned = landmark.CheckinPoints,
                CheckinId = newCheckin.Id
            };
        }
        public async Task<CheckinResponse> AttachPhotoAsync(string checkinId, string photoUrl)
        {
            bool success = await checkinRepo.AddPhotoAsync(checkinId, photoUrl);

            if (!success)
            {
                return new CheckinResponse { IsSuccess = false, Message = "Чекирането не е намерено!" };
            }

            return new CheckinResponse { IsSuccess = true, Message = "Снимката е добавена успешно!" };
        }

        // --- МАТЕМАТИКАТА ЗА РАЗСТОЯНИЕТО (Хаверсин) ---
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var r = 6371e3;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return r * c;
        }

        private double ToRadians(double angle) => Math.PI * angle / 180.0;
    }
}
