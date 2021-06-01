using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.ApplicationServices
{
    public class ActivityApplication : IActivityApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public ActivityApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Activity>> GetActivity()
        {
            return await dc.Activity.ToListAsync();
        }
        public Task<ActionResult<Activity>> FindActivity(int activityId)
        {
            var activity = uow.ActivityDomainService.FindActivity(activityId);
            if (activity != null)
            {
                return activity;
            }
            return null;

        }
        public async Task<IActionResult> AddActivity(Activity activity)
        {
            var RequiredField = uow.ActivityDomainService.PostActivity(activity);
            if (!RequiredField)
            {
                dc.Activity.Add(activity);
                await dc.SaveChangesAsync();
                return new ObjectResult(activity);
            }
            return null;
        }
        public async Task<ActionResult> UpdateActivity(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return null;

            }
            dc.Entry(activity).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            var activity = uow.ActivityDomainService.DomainDeleteActivity(activityId);
            if (activity == null)
            {
                return null;
            }
            dc.Activity.Remove(activity);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }


    }
}
