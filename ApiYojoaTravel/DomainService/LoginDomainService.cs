using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class LoginDomainService :ILoginDomainService
    {
        private readonly ApiDataContext dc;
        public LoginDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
         public async Task<User> FindUser(LoginReqDTO User)
        {
            return await dc.User.FirstOrDefaultAsync(x => x.UserName == User.UserName && x.Password == User.Password);
        }
    }
}