using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApiDataContext dc;
        private readonly ActivityDomainService activityDomainService;

        public ActivityRepository(ApiDataContext dc, ActivityDomainService activityDomainService)
        {
            this.activityDomainService = activityDomainService;
            this.dc = dc;
        }
        public async Task<IEnumerable<Activity>> GetActivity()
        {
            return await dc.Activity.ToListAsync();
        }
        public async Task<bool> AddActivity(Activity activity)
        {
            bool isRequired = activityDomainService.PostActivity(activity);
            if (isRequired)
            {
                return isRequired;
            }
            dc.Activity.Add(activity);
            await dc.SaveChangesAsync();
            return false;
        }
        public void DeleteActivity(int activityId)
        {
            var activity = dc.Activity.Find(activityId);
            dc.Activity.Remove(activity);
        }
        public async Task UpdateActivity(Activity activity)
        {
            dc.Entry(activity).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Activity> FindActivity(int activityId)
        {
            return await dc.Activity.FindAsync(activityId);
        }
    }
}