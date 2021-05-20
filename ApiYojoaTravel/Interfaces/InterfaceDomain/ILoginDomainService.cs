using System.Threading.Tasks;
using ApiYojoaTravel.DTO;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface ILoginDomainService
    {
        Task<User> FindUser(LoginReqDTO User);
    }
}