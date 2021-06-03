using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class UserDomainService : IUserDomainservice
    {
         private readonly ApiDataContext dc;
        public UserDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostUser(User User)
        {
            bool requiredField;
            requiredField = (User.Name == null) ? true : false;
            requiredField = (User.Email == null) ? true : false;
            requiredField = (User.PhoneNumber == null) ? true : false;
            requiredField = (User.Password == null) ? true : false;
            return requiredField;
        }
        public async Task<ActionResult<User>> FindUser(int UserId)
        {
            var User = await dc.User.FirstOrDefaultAsync(x => x.ClientId == UserId);
            return User;
        }
        public User DomainDeleteUser(int id)
        {
            var User = dc.User.Find(id);
            if (User == null)
            {
                return null;
            }
            return User;
        }
    }
}