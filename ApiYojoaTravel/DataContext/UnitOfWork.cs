using System.Threading.Tasks;
using ApiYojoaTravel.ApplicationServices;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;

namespace ApiYojoaTravel.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        private readonly LoginResDTO loginResDTO;

        public UnitOfWork(ApiDataContext dc, IDomainUnitOfWork uow, LoginResDTO loginResDTO)
        {
            this.uow = uow;
            this.loginResDTO = loginResDTO;
            this.dc = dc;

        }
        public IBookingApplication BookingApplication =>
        new BookingApplication(dc, uow);
        public ICategoryApplication CategoryApplication =>
        new CategoryApplication(dc, uow);
        public IClassificationApplication ClassificationApplication =>
        new ClassificationApplication(dc, uow);
        public IClientApplication ClientApplication =>
        new ClientApplication(dc, uow);
        public IPackageApplication PackageApplication =>
        new PackageApplication(dc, uow);
        public IPackageByActivityApplication PackageByActivityApplication =>
        new PackageByActivityApplication(dc, uow);
        public IPackageByCategoryApplication PackageByCategoryApplication =>
        new PackageByCategoryApplication(dc, uow);
        public IPolicyApplication PolicyApplication =>
        new PolicyApplication(dc, uow);
        public IUserApplication UserApplication =>
        new UserApplicationServices(dc);
        public IActivityApplication ActivityApplication =>
        new ActivityApplication(dc, uow);
        public ILoginApplication LoginApplication =>
        new LoginApplication(loginResDTO, uow);


        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}