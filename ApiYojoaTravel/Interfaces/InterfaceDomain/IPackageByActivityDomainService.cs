using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByActivityDomainService
    {
        bool PostPackageByActivity(PackageByActivity PackageByActivity);
        Task<ActionResult<PackageByActivity>> FindPackageByActivity(int PackageByActivityId);
        PackageByActivity DomainDeletePackageByActivity(int id);
    }
}