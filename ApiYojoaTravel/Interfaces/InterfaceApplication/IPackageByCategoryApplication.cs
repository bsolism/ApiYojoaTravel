using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByCategoryApplication
    {
       Task<IEnumerable<PackageByCategory>> GetPackageByCategory();
        Task<ActionResult<PackageByCategory>> FindPackageByCategory(int packageByCategoryId);
        Task<IActionResult> AddPackageByCategory(PackageByCategory packageByCategory);
        Task<ActionResult> UpdatePackageByCategory(int id, PackageByCategory packageByCategory);
        Task<IActionResult> DeletePackageByCategory(int packageByCategoryId);
    }
}