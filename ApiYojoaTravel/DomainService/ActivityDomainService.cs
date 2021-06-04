using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
         public Activity DomainDeleteActivity(int id)
        {
            var Activity = dc.Activity.Find(id);
            if (Activity == null)
            {
                return null;
            }
            return Activity;
        }
        public async Task<ActionResult<Activity>> FindActivity(int ActivityId)
        {
            var Activity = await dc.Activity.FirstOrDefaultAsync(x => x.ActivityId == ActivityId);
            return Activity;
        }
        public IEnumerable<Activity> FindActivityForUser(IEnumerable<dynamic> data)
        {
            List<Activity> actividad= new();
                      
            foreach(var i in data)
            {
                Activity act= new();
                act.ActivityId= i.pbi.Activity.ActivityId;
                act.Name= i.pbi.Activity.Name;
                act.Description= i.pbi.Activity.Description;
                act.InitTime= i.pbi.Activity.InitTime;
                act.EndTime= i.pbi.Activity.EndTime;
                act.Price= i.pbi.Activity.Price;
                act.ImageURL= i.pbi.Activity.ImageURL;
                act.ClientId=i.pbi.Activity.ClientId;
                actividad.Add(act);

            }
            return  actividad;

        }
       
        public bool PostActivity(ActivityDTO activity)
        {
            if(activity.Name==null) return true;
            if(activity.Description==null) return true;
            if(activity.InitTime == new DateTime(0)) return true;
            if(activity.EndTime == new DateTime(0)) return true;
            if(activity.Price == 0) return true;
            if(activity.ImageURL == null) return true;
            if(activity.File == null) return true;
            return false;
           
        }
        public ActivityDTO UploadImage(ActivityDTO activityDto)
        {
            string guidImagen;
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
        
       
    }
}