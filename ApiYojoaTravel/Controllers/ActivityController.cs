using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class ActivityController : BaseController
    {
        private readonly IUnitOfWork uow;
        public ActivityController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetActivity()
        {
            var Activity = await uow.ActivityRepository.GetActivity();
            return Ok(Activity);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(int activityId)
        {
            return await uow.ActivityRepository.FindActivity(activityId);
        }
        [HttpPost]
        public async Task<IActionResult> AddActivity(Activity activity)
        {
            uow.ActivityRepository.AddActivity(activity);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return BadRequest();
            }
            await uow.ActivityRepository.UpdateActivity(activity);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            uow.ActivityRepository.DeleteActivity(activityId);
            await uow.SaveAsync();
            return Ok(activityId);
        }
    }
}