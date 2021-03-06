using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using AutoMapper;
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
        private readonly IMapper mapper;

        public ActivityApplication(ApiDataContext dc, IDomainUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
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
        public async Task<IEnumerable<Activity>> FindActivityForUser(int userId)
        {
            var packageByActivity= await dc.PackageByActivity.
            Include(x=> x.Activity).
            Include(z=> z.Package).
            Join(dc.Booking, 
            pbi => pbi.PackageId, 
            book => book.PackageId, 
            (pbi, book)=> new {pbi, book}).
            Where(i=> i.book.ClientId==userId)
            .ToListAsync();

            var activities = uow.ActivityDomainService.FindActivityForUser(packageByActivity);          
            return activities;

        }
        public async Task<IActionResult> AddActivity(ActivityDTO activity)
        {
            var RequiredField = uow.ActivityDomainService.PostActivity(activity);
            var CreateImage = uow.ActivityDomainService.UploadImage(activity);
            
            if (!RequiredField && CreateImage != null)
            {
                var activityModel = mapper.Map<Activity>(activity);
                dc.Activity.Add(activityModel);
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
