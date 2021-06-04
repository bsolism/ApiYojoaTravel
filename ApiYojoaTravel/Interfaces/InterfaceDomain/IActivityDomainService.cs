using System.Collections.Generic;
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
        IEnumerable<Activity> FindActivityForUser(IEnumerable<dynamic> data);
        ActivityDTO UploadImage(ActivityDTO activityDto);
        Activity DomainDeleteActivity(int id);
    }
}