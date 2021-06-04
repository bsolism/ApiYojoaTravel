using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IActivityApplication
    {
        Task<IEnumerable<Activity>> GetActivity();
        Task<ActionResult<Activity>> FindActivity(int activityId);
        Task<IEnumerable<Activity>> FindActivityForUser(int userId);
        Task<IActionResult> AddActivity(ActivityDTO activity);
        Task<ActionResult> UpdateActivity(int id, Activity activity);
        Task<IActionResult> DeleteActivity(int activityId);
    }
}
