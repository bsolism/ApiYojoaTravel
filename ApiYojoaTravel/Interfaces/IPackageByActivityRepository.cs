using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByActivityRepository
    {
        Task<IEnumerable<PackageByActivity>> GetPackageByActivity();
        void AddPackageByActivity(PackageByActivity packageByActivity);
        void DeletePackageByActivity(int packageByActivityId);
        Task UpdatePackageByActivity(PackageByActivity packageByActivity);
        Task<PackageByActivity> FindPackageByActivity(int packageByActivityId);
    }
}