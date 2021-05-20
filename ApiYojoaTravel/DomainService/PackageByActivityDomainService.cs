using System;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class PackageByActivityDomainService: IPackageByActivityDomainService
    {
        private readonly ApiDataContext dc;
        public PackageByActivityDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostPackageByActivity(PackageByActivity PackageByActivity)
        {
            bool requiredField;
            requiredField = (PackageByActivity.PackageId ==  0) ? true : false;
            requiredField = (PackageByActivity.ActivityId == 0)? true : false;
            return requiredField;
        }      
       
        
       
        public async Task<ActionResult<PackageByActivity>> FindPackageByActivity(int PackageByActivityId)
        {
            var PackageByActivity = await dc.PackageByActivity.FirstOrDefaultAsync(x => x.Id== PackageByActivityId);
            return PackageByActivity;
        }
        public PackageByActivity DomainDeletePackageByActivity(int id)
        {
            var PackageByActivity = dc.PackageByActivity.Find(id);
            if (PackageByActivity == null)
            {
                return null;
            }
            return PackageByActivity;
        }
        
    }
}