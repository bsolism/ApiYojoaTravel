using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class PackageByActivityRepository : IPackageByActivityRepository
    {
        private readonly ApiDataContext dc;

        public PackageByActivityRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<PackageByActivity>> GetPackageByActivity()
        {
            return await dc.PackageByActivity.ToListAsync();
        }
        public void AddPackageByActivity(PackageByActivity packageByActivity)
        {
            dc.PackageByActivity.AddAsync(packageByActivity);
        }
        public void DeletePackageByActivity(int packageByActivityId)
        {
            var packageByActivity = dc.PackageByActivity.Find(packageByActivityId);
            dc.PackageByActivity.Remove(packageByActivity);
        }
        public async Task UpdatePackageByActivity(PackageByActivity packageByActivity)
        {
            dc.Entry(packageByActivity).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<PackageByActivity> FindPackageByActivity(int packageByActivityId)
        {
            return await dc.PackageByActivity.FindAsync(packageByActivityId);
        }

    }
}