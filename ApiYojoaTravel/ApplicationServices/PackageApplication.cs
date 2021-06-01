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
    public class PackageApplication: IPackageApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public PackageApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Package>> GetPackage()
        {
            return await dc.Package.ToListAsync();
        }
        public Task<ActionResult<Package>> FindPackage(int PackageId)
        {
            var Package = uow.PackageDomainService.FindPackage(PackageId);
            if (Package != null)
            {
                return Package;
            }
            return null;

        }
        public async Task<IActionResult> AddPackage(Package Package)
        {
            var RequiredField = uow.PackageDomainService.PostPackage(Package);
            if (!RequiredField)
            {
                dc.Package.Add(Package);
                await dc.SaveChangesAsync();
                return new ObjectResult(Package);
            }
            return null;
        }
        public async Task<ActionResult> UpdatePackage(int id, Package Package)
        {
            if (id != Package.PackageId)
            {
                return null;

            }
            dc.Entry(Package).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeletePackage(int PackageId)
        {
            var Package = uow.PackageDomainService.DomainDeletePackage(PackageId);
            if (Package == null)
            {
                return null;
            }
            dc.Package.Remove(Package);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}