using ApiYojoaTravel.Interfaces;

namespace ApiYojoaTravel.DomainService
{
    public interface IDomainUnitOfWork
    {
        IActivityDomainService ActivityDomainService { get; }
        IBookingDomainservice BookingDomainService { get; }
        ICategoryDomainService CategoryDomainService { get; }
        IClassificationDomainService ClassificationDomainService { get; }
        IClientDomainService ClientDomainService { get; }
        IPackageDomainService PackageDomainService { get; }
        IPackageByActivityDomainService PackageByActivityDomainService { get; }
        IPackageByCategoryDomainService PackageByCategoryDomainService { get; }
        IPolicyDomainService PolicyDomainService { get; }
        ICreateToken CreateToken { get; }
        ILoginDomainService LoginDomainService {get;}
    }
}