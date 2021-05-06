using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetActivity();
        void AddActivity(Activity activity);
        void DeleteActivity(int activityId);
        Task UpdateActivity(Activity activity);
        Task<Activity> FindActivity(int activityId);

    }
}