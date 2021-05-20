using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageApplication
    {
       Task<IEnumerable<Package>> GetPackage();
        Task<ActionResult<Package>> FindPackage(int packageId);
        Task<IActionResult> AddPackage(Package package);
        Task<ActionResult> UpdatePackage(int id, Package package);
        Task<IActionResult> DeletePackage(int packageId);
    }
}