using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class PackageByCategoryRepository : IPackageByCategoryRepository
    {
        private readonly ApiDataContext dc;

        public PackageByCategoryRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<PackageByCategory>> GetPackageByCategory()
        {
            return await dc.PackageByCategory.ToListAsync();
        }
        public void AddPackageByCategory(PackageByCategory packageByCategory)
        {
            dc.PackageByCategory.AddAsync(packageByCategory);
        }
        public void DeletePackageByCategory(int packageByCategoryId)
        {
            var packageByCategory = dc.PackageByCategory.Find(packageByCategoryId);
            dc.PackageByCategory.Remove(packageByCategory);
        }
        public async Task UpdatePackageByCategory(PackageByCategory packageByCategory)
        {
            dc.Entry(packageByCategory).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<PackageByCategory> FindPackageByCategory(int packageByCategoryId)
        {
            return await dc.PackageByCategory.FindAsync(packageByCategoryId);
        }
    }
}