using System.Threading.Tasks;
using ApiYojoaTravel.DTO;

namespace ApiYojoaTravel.Interfaces
{
    public interface ILoginApplication
    {
        Task<LoginResDTO> Login(LoginReqDTO loginReqDTO);
    }
}