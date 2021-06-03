using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApiYojoaTravel.DomainService
{
    public class ActivityDomainService : IActivityDomainService
    {
        private readonly ApiDataContext dc;
        private readonly IWebHostEnvironment environment;

        public ActivityDomainService(ApiDataContext dc, IWebHostEnvironment environment)
        {
            this.dc = dc;
            this.environment = environment;
        }
        public ActivityDomainService()
        {
            
        }
        public bool PostActivity(ActivityDTO activity)
        {
            bool requiredField;
            requiredField = (activity.Name == null) ? true : false;
            requiredField = (activity.Description == null) ? true : false;
            requiredField = (activity.InitTime == new DateTime(0)) ? true : false;
            requiredField = (activity.EndTime == new DateTime(0)) ? true : false;
            requiredField = (activity.Price == 0) ? true : false;
            requiredField = (activity.ImageURL == null) ? true : false;
            requiredField = (activity.File == null) ? true : false;
            return requiredField;
        }
        public ActivityDTO UploadImage(ActivityDTO activityDto)
        {
            string guidImagen = null;
            if (activityDto.File != null)
            {
                if (!Directory.Exists(environment.WebRootPath + "\\activity\\"))
                {
                    Directory.CreateDirectory(environment.WebRootPath + "\\activity\\");
                }
                string fichero = Path.Combine(environment.WebRootPath, "activity");
                guidImagen = Guid.NewGuid().ToString() + activityDto.File.FileName;
                string url = Path.Combine(fichero, guidImagen);
                activityDto.File.CopyTo(new FileStream(url, FileMode.Create));

                activityDto.ImageURL = guidImagen;


                return activityDto;
            }

            return null;
        }
        public async Task<ActionResult<Activity>> FindActivity(int ActivityId)
        {
            var Activity = await dc.Activity.FirstOrDefaultAsync(x => x.ActivityId == ActivityId);
            return Activity;
        }
        public async Task<ActionResult<Activity>> FindActivityForUser(int userId)
        {
            var Activity = await dc.Activity.FirstOrDefaultAsync(x => x.ClientId == userId);
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