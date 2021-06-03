using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DTO;
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
        public Task<IEnumerable<Activity>> GetActivity()
        {
            return uow.ActivityApplication.GetActivity();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Activity>> GetById(int id)
        {
            var activity = uow.ActivityApplication.FindActivity(id);
            return activity;
        }
        [HttpGet("user/{id}")]
        public Task<IEnumerable<Activity>> GetByUserId(int id)
        {
            return uow.ActivityApplication.FindActivityForUser(id);
            
        }
        [HttpPost]
        public async Task<ActionResult<ActivityDTO>> AddActivity([FromForm]ActivityDTO activity)
        {
            var activit = await uow.ActivityApplication.AddActivity(activity);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            var Activity = await uow.ActivityApplication.UpdateActivity(id, activity);
            if (Activity == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var Activity = await uow.ActivityApplication.DeleteActivity(id);
            if (Activity == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}