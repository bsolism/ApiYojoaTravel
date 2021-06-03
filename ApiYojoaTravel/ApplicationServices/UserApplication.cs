using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class UserApplication : IUserApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public UserApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<User>> GetUser()
        {
            return await dc.User.ToListAsync();
        }
        public Task<ActionResult<User>> FindUser(int UserId)
        {
            var User = uow.UserDomainService.FindUser(UserId);
            if (User != null)
            {
                return User;
            }
            return null;

        }
        public async Task<IActionResult> AddUser(User User)
        {
            var RequiredField = uow.UserDomainService.PostUser(User);
            if (!RequiredField)
            {
                dc.User.Add(User);
                await dc.SaveChangesAsync();
                return new ObjectResult(User);
            }
            return null;
        }
        public async Task<ActionResult> UpdateUser(int id, User User)
        {
            if (id != User.ClientId)
            {
                return null;

            }
            dc.Entry(User).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var User = uow.UserDomainService.DomainDeleteUser(UserId);
            if (User == null)
            {
                return null;
            }
            dc.User.Remove(User);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}