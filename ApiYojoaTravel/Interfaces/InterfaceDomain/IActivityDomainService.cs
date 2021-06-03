using System.Threading.Tasks;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IActivityDomainService
    {
        bool PostActivity(ActivityDTO activity);
        Task<ActionResult<Activity>> FindActivity(int ActivityId);
        Task<ActionResult<Activity>> FindActivityForUser(int ActivityId);
        ActivityDTO UploadImage(ActivityDTO activityDto);
        Activity DomainDeleteActivity(int id);
    }
}