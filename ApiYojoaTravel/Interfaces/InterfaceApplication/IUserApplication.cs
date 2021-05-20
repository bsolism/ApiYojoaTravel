using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiYojoaTravel.Interfaces
{
    public interface IUserApplication
    {
        Task<IEnumerable<User>> GetUser();
        void AddUser(User User);
        void DeleteUser(int UserId);
        Task UpdateUser(User User);
        Task<User> FindUser(LoginReqDTO UserId);
    }
}
