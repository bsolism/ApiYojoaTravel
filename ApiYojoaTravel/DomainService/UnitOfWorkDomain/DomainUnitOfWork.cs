using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApiYojoaTravel.DomainService
{
    public class DomainUnitOfWork : IDomainUnitOfWork
    {
        private readonly ApiDataContext dc;
        private readonly IConfiguration configuration;
        public DomainUnitOfWork(ApiDataContext dc, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dc = dc;

        }
        public IActivityDomainService ActivityDomainService =>
        new ActivityDomainService(dc);
        public IBookingDomainservice BookingDomainService =>
        new BookingDomainService(dc);
        public ICategoryDomainService CategoryDomainService =>
        new CategoryDomainService(dc);
        public IClassificationDomainService ClassificationDomainService =>
        new ClassificationDomainService(dc);
        public IClientDomainService ClientDomainService =>
       new ClientDomainService(dc);
        public IPackageDomainService PackageDomainService =>
        new PackageDomainService(dc);
        public IPackageByActivityDomainService PackageByActivityDomainService =>
        new PackageByActivityDomainService(dc);
        public IPackageByCategoryDomainService PackageByCategoryDomainService =>
        new PackageByCategoryDomainService(dc);
        public IPolicyDomainService PolicyDomainService =>
        new PolicyDomainService(dc);
        public ICreateToken CreateToken =>
        new CreateToken(configuration);
        public ILoginDomainService LoginDomainService =>
        new LoginDomainService(dc);
        public IRegisterDomainService RegisterDomainService =>
        new RegisterDomainService(dc);
    }
}