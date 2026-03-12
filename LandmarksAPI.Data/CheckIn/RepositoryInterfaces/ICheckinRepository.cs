using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarksAPI.Data.CheckIn.RepositoryInterfaces
{
    public interface ICheckinRepository
    {// Проверява дали има запис за този потребител и обект след определена дата
        Task<bool> HasCheckedInAfterAsync(string userId, string landmarkId, DateTime date);

        // Записва новото чекиране
        Task AddAsync(EntitiesModels.Checkin checkin);
    }
}
