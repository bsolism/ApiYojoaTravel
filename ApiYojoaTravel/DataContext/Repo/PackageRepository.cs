using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApiDataContext dc;

        public PackageRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Package>> GetPackage()
        {
            return await dc.Package.ToListAsync();
        }
        public void AddPackage(Package package)
        {
            dc.Package.AddAsync(package);
        }
        public void DeletePackage(int packageId)
        {
            var package = dc.Package.Find(packageId);
            dc.Package.Remove(package);
        }
        public async Task UpdatePackage(Package package)
        {
            dc.Entry(package).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Package> FindPackage(int packageId)
        {
            return await dc.Package.FindAsync(packageId);
        }
    }
}