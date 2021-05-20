using System;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class PackageByCategoryDomainService: IPackageByCategoryDomainService
    {
        private readonly ApiDataContext dc;
        public PackageByCategoryDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostPackageByCategory(PackageByCategory PackageByCategory)
        {
            bool requiredField;
            requiredField = (PackageByCategory.PackageId ==  0) ? true : false;
            requiredField = (PackageByCategory.CategoryId == 0)? true : false;
            return requiredField;
        }      
      
        public async Task<ActionResult<PackageByCategory>> FindPackageByCategory(int PackageByCategoryId)
        {
            var PackageByCategory = await dc.PackageByCategory.FirstOrDefaultAsync(x => x.Id== PackageByCategoryId);
            return PackageByCategory;
        }
        public PackageByCategory DomainDeletePackageByCategory(int id)
        {
            var PackageByCategory = dc.PackageByCategory.Find(id);
            if (PackageByCategory == null)
            {
                return null;
            }
            return PackageByCategory;
        }
        
    }
}