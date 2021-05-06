using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApiDataContext dc;

        public ActivityRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Activity>> GetActivity()
        {
            return await dc.Activity.ToListAsync();
        }
        public void AddActivity(Activity activity)
        {
            dc.Activity.AddAsync(activity);
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