using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.ApplicationServices
{
    public class UserApplicationServices: IUserApplication
    {
        private readonly ApiDataContext dc;

        public UserApplicationServices(ApiDataContext dc )
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            return await dc.User.ToListAsync();
        }
        public void AddUser(User User)
        {
            dc.User.AddAsync(User);
        }
        public void DeleteUser(int UserId)
        {
            var User = dc.User.Find(UserId);
            dc.User.Remove(User);
        }
        public async Task UpdateUser(User User)
        {
            dc.Entry(User).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<User> FindUser(LoginReqDTO User)
        {
            return await dc.User.FirstOrDefaultAsync(x => x.UserName == User.UserName && x.Password == User.Password);
        }

    }
}
