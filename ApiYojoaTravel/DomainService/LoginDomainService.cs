using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Helper;
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
            var user = await dc.User.FirstOrDefaultAsync(x => x.UserName == User.UserName);
            if (user==null)
            {
                return null;
            }
            var verification = HashHelper.CheckHash(User.Password, user.Password, user.Sal);
            if(verification== false)
            {
                return null;
            }
            

            return user;
        }
    }
}