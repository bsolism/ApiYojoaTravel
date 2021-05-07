using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClient();
        void AddClient(Client client);
        void DeleteClient(int clientId);
        Task UpdateClient(Client client);
        Task<Client> FindClient(int clientId);
    }
}