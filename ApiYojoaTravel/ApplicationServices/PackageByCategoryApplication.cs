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
    public class PackageByCategoryApplication : IPackageByCategoryApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public PackageByCategoryApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<PackageByCategory>> GetPackageByCategory()
        {
            return await dc.PackageByCategory.ToListAsync();
        }
        public Task<ActionResult<PackageByCategory>> FindPackageByCategory(int PackageByCategoryId)
        {
            var PackageByCategory = uow.PackageByCategoryDomainService.FindPackageByCategory(PackageByCategoryId);
            if (PackageByCategory != null)
            {
                return PackageByCategory;
            }
            return null;

        }
        public async Task<IActionResult> AddPackageByCategory(PackageByCategory PackageByCategory)
        {
            var RequiredField = uow.PackageByCategoryDomainService.PostPackageByCategory(PackageByCategory);
            if (!RequiredField)
            {
                dc.PackageByCategory.Add(PackageByCategory);
                await dc.SaveChangesAsync();
                return new ObjectResult(PackageByCategory);
            }
            return null;
        }
        public async Task<ActionResult> UpdatePackageByCategory(int id, PackageByCategory PackageByCategory)
        {
            if (id != PackageByCategory.Id)
            {
                return null;

            }
            dc.Entry(PackageByCategory).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeletePackageByCategory(int PackageByCategoryId)
        {
            var PackageByCategory = uow.PackageByCategoryDomainService.DomainDeletePackageByCategory(PackageByCategoryId);
            if (PackageByCategory == null)
            {
                return null;
            }
            dc.PackageByCategory.Remove(PackageByCategory);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}