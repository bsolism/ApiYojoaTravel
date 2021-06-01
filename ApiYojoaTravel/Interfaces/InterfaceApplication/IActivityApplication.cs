using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IActivityApplication
    {
        Task<IEnumerable<Activity>> GetActivity();
        Task<ActionResult<Activity>> FindActivity(int activityId);
        Task<IActionResult> AddActivity(Activity activity);
        Task<ActionResult> UpdateActivity(int id, Activity activity);
        Task<IActionResult> DeleteActivity(int activityId);
    }
}
