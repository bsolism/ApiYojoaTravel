using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces
{
    public interface IUnitOfWork
    {
        IActivityRepository ActivityRepository { get; }
        IBookingRepository BookingRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IClassificationRepository ClassificationRepository { get; }
        IClientRepository ClientRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPackageByActivityRepository PackageByActivityRepository { get; }
        IPackageByCategoryRepository PackageByCategoryRepository { get; }
        IPolicyRepository PolicyRepository { get; }

        Task<bool> SaveAsync();
    }
}