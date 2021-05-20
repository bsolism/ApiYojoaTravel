using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class PackageByActivityApplication : IPackageByActivityApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public PackageByActivityApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<PackageByActivity>> GetPackageByActivity()
        {
            return await dc.PackageByActivity.ToListAsync();
        }
        public Task<ActionResult<PackageByActivity>> FindPackageByActivity(int PackageByActivityId)
        {
            var PackageByActivity = uow.PackageByActivityDomainService.FindPackageByActivity(PackageByActivityId);
            if (PackageByActivity != null)
            {
                return PackageByActivity;
            }
            return null;

        }
        public async Task<IActionResult> AddPackageByActivity(PackageByActivity PackageByActivity)
        {
            var RequiredField = uow.PackageByActivityDomainService.PostPackageByActivity(PackageByActivity);
            if (!RequiredField)
            {
                dc.PackageByActivity.Add(PackageByActivity);
                await dc.SaveChangesAsync();
                return new ObjectResult(PackageByActivity);
            }
            return null;
        }
        public async Task<ActionResult> UpdatePackageByActivity(int id, PackageByActivity PackageByActivity)
        {
            if (id != PackageByActivity.Id)
            {
                return null;

            }
            dc.Entry(PackageByActivity).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeletePackageByActivity(int PackageByActivityId)
        {
            var PackageByActivity = uow.PackageByActivityDomainService.DomainDeletePackageByActivity(PackageByActivityId);
            if (PackageByActivity == null)
            {
                return null;
            }
            dc.PackageByActivity.Remove(PackageByActivity);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}