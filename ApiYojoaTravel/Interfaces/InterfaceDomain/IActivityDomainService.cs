using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IActivityDomainService
    {
        bool PostActivity(Activity activity);
        Task<ActionResult<Activity>> FindActivity(int ActivityId);
        Activity DomainDeleteActivity(int id);
    }
}