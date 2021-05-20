using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageDomainService
    {
        bool PostPackage(Package Package);
        Task<ActionResult<Package>> FindPackage(int PackageId);
        Package DomainDeletePackage(int id);
    }
}