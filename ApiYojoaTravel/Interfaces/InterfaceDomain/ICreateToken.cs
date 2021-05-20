using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface ICreateToken
    {
        string CreateJWT(User user);
        
    }
}