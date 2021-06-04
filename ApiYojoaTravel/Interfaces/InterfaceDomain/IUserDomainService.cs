using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IUserDomainservice
    {
        bool PostUser(User User);
        Task<ActionResult<User>> FindUser(int UserId);
        User DomainDeleteUser(int id);
    }
}