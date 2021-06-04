using System.Threading.Tasks;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;

namespace ApiYojoaTravel.ApplicationServices
{
    public class LoginApplication : ILoginApplication
    {
        
        private readonly LoginResDTO loginResDTO;
        private readonly IDomainUnitOfWork duow;

        public LoginApplication(LoginResDTO loginResDTO,  IDomainUnitOfWork duow)
        {
            this.duow = duow;
            this.loginResDTO = loginResDTO;
        }

        public async Task<LoginResDTO> Login(LoginReqDTO loginReqDTO)
        {
            var user = await duow.LoginDomainService.FindUser(loginReqDTO);

            if (user == null)
            {
                return null;
            }
            loginResDTO.UserName = user.UserName;
            loginResDTO.Token = duow.CreateToken.CreateJWT(user);
            return loginResDTO;
        }
    }
}
