using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces.InterfaceApplication
{
    public interface IUserApplicationServices
    {
         Task<IEnumerable<User>> GetUser();
         Task AddUser(User User);
         void DeleteUser(int UserId);
         Task UpdateUser(User User);
         Task<User> FindUser(LoginReqDTO User);
    }
}