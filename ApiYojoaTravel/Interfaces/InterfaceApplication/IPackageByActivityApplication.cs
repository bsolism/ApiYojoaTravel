using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByActivityApplication
    {
       Task<IEnumerable<PackageByActivity>> GetPackageByActivity();
        Task<ActionResult<PackageByActivity>> FindPackageByActivity(int packageByActivityd);
        Task<IActionResult> AddPackageByActivity(PackageByActivity packageByActivity);
        Task<ActionResult> UpdatePackageByActivity(int id, PackageByActivity packageByActivity);
        Task<IActionResult> DeletePackageByActivity(int packageByActivityd);
    }
}