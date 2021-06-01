using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByCategoryDomainService
    {
        bool PostPackageByCategory(PackageByCategory PackageByCategory);
        Task<ActionResult<PackageByCategory>> FindPackageByCategory(int PackageByCategoryId);
        PackageByCategory DomainDeletePackageByCategory(int id);
    }
}