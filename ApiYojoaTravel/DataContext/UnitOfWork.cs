using System.Threading.Tasks;
using ApiYojoaTravel.ApplicationServices;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Interfaces.InterfaceApplication;
using AutoMapper;

namespace ApiYojoaTravel.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork duow;
        private readonly LoginResDTO loginResDTO;
        private readonly IMapper mapper;

        public UnitOfWork(ApiDataContext dc, IDomainUnitOfWork duow, LoginResDTO loginResDTO, IMapper mapper)
        {
            this.duow = duow;
            this.loginResDTO = loginResDTO;
            this.mapper = mapper;
            this.dc = dc;

        }
        public IBookingApplication BookingApplication =>
        new BookingApplication(dc, duow);
        public ICategoryApplication CategoryApplication =>
        new CategoryApplication(dc, duow);
        public IClassificationApplication ClassificationApplication =>
        new ClassificationApplication(dc, duow);
        public IClientApplication ClientApplication =>
        new ClientApplication(dc, duow);
        public IPackageApplication PackageApplication =>
        new PackageApplication(dc, duow);
        public IPackageByActivityApplication PackageByActivityApplication =>
        new PackageByActivityApplication(dc, duow);
        public IPackageByCategoryApplication PackageByCategoryApplication =>
        new PackageByCategoryApplication(dc, duow);
        public IPolicyApplication PolicyApplication =>
        new PolicyApplication(dc, duow);
        public IUserApplicationServices UserApplicationServices =>
        new UserApplicationServices(dc);
        public IActivityApplication ActivityApplication =>
        new ActivityApplication(dc, duow, mapper);
        public ILoginApplication LoginApplication =>
        new LoginApplication(loginResDTO, duow);
        public IRegisterApplication RegisterApplication =>
            new RegisterApplication(duow, loginResDTO);
        
        public IUserApplication UserApplication =>
        new UserApplication(dc, duow);


      
    }
}