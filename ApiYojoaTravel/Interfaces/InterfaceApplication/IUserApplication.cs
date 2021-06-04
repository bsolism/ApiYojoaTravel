using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IUserApplication
    {
       Task<IEnumerable<User>> GetUser();
        Task<ActionResult<User>> FindUser(int UserId);
        Task<IActionResult> AddUser(User User);
        Task<ActionResult> UpdateUser(int id, User User);
        Task<IActionResult> DeleteUser(int UserId);
    }
}