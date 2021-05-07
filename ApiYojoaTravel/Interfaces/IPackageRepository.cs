using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPackageRepository
    {
        Task<IEnumerable<Package>> GetPackage();
        void AddPackage(Package package);
        void DeletePackage(int packageId);
        Task UpdatePackage(Package package);
        Task<Package> FindPackage(int packageId);
    }
}