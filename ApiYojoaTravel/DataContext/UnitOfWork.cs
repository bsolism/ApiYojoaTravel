using System.Data.Common;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext.Repo;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;

namespace ApiYojoaTravel.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDataContext dc;
        private readonly ActivityDomainService activityDomainService;
        public UnitOfWork(ApiDataContext dc, ActivityDomainService activityDomainService)
        {
            this.activityDomainService = activityDomainService;
            this.dc = dc;

        }
        public IActivityRepository ActivityRepository =>
        new ActivityRepository(dc, activityDomainService);
        public IBookingRepository BookingRepository =>
        new BookingRepository(dc);
        public ICategoryRepository CategoryRepository =>
        new CategoryRepository(dc);
        public IClassificationRepository ClassificationRepository =>
        new ClassificationRepository(dc);
        public IClientRepository ClientRepository =>
        new ClientRepository(dc);
        public IPackageRepository PackageRepository =>
        new PackageRepository(dc);
        public IPackageByActivityRepository PackageByActivityRepository =>
        new PackageByActivityRepository(dc);
        public IPackageByCategoryRepository PackageByCategoryRepository =>
        new PackageByCategoryRepository(dc);
        public IPolicyRepository PolicyRepository =>
        new PolicyRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}