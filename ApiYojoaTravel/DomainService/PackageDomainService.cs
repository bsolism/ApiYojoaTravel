using System;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class PackageDomainService: IPackageDomainService
    {
        private readonly ApiDataContext dc;
        public PackageDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostPackage(Package Package)
        {
            bool requiredField;
            requiredField = (Package.InitialDate ==  new DateTime(0)) ? true : false;
            requiredField = (Package.EndDate == new DateTime(0)) ? true : false;
            requiredField = (Package.Duration == 0) ? true : false;
            requiredField = (Package.PolicyId==0) ? true : false;
            requiredField = (Package.Subtotal == 0) ? true : false;
            return requiredField;
        }        
        public async Task<ActionResult<Package>> FindPackage(int PackageId)
        {
            var Package = await dc.Package.FirstOrDefaultAsync(x => x.PackageId == PackageId);
            return Package;
        }
        public Package DomainDeletePackage(int id)
        {
            var Package = dc.Package.Find(id);
            if (Package == null)
            {
                return null;
            }
            return Package;
        }
        
    }
}