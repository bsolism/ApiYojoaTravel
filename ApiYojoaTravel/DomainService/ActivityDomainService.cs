using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiYojoaTravel.DomainService
{
    public class ActivityDomainService : IActivityDomainService
    {
        private readonly ApiDataContext dc;
        public ActivityDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public ActivityDomainService()
        {
            
        }
        public bool PostActivity(Activity activity)
        {
            bool requiredField;
            requiredField = (activity.Name == null) ? true : false;
            requiredField = (activity.Description == null) ? true : false;
            requiredField = (activity.InitTime == new DateTime(0)) ? true : false;
            requiredField = (activity.EndTime == new DateTime(0)) ? true : false;
            requiredField = (activity.Price == 0) ? true : false;
            requiredField = (activity.ImageURL == null) ? true : false;
            return requiredField;
        }
        public async Task<ActionResult<Activity>> FindActivity(int ActivityId)
        {
            var Activity = await dc.Activity.FirstOrDefaultAsync(x => x.ActivityId == ActivityId);
            return Activity;
        }
        public Activity DomainDeleteActivity(int id)
        {
            var Activity = dc.Activity.Find(id);
            if (Activity == null)
            {
                return null;
            }
            return Activity;
        }
    }
}