using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageByCategoryRepository
    {
        Task<IEnumerable<PackageByCategory>> GetPackageByCategory();
        void AddPackageByCategory(PackageByCategory packageByCategory);
        void DeletePackageByCategory(int packageByCategoryId);
        Task UpdatePackageByCategory(PackageByCategory packageByCategory);
        Task<PackageByCategory> FindPackageByCategory(int packageByCategoryId);
    }
}