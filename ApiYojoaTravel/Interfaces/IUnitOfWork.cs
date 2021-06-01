using ApiYojoaTravel.Interfaces.InterfaceApplication;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces
{
    public interface IUnitOfWork
    {
        IBookingApplication BookingApplication { get; }
        ICategoryApplication CategoryApplication { get; }
        IClassificationApplication ClassificationApplication { get; }
        IClientApplication ClientApplication { get; }
        IPackageApplication PackageApplication { get; }
        IPackageByActivityApplication PackageByActivityApplication { get; }
        IPackageByCategoryApplication PackageByCategoryApplication { get; }
        IPolicyApplication PolicyApplication { get; }
        IUserApplication UserApplication { get; }
        IActivityApplication ActivityApplication { get; }
        ILoginApplication LoginApplication { get; }
        IRegisterApplication RegisterApplication { get; }



        Task<bool> SaveAsync();
    }
}