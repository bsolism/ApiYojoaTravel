using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClientApplication
    {
       Task<IEnumerable<Client>> GetClient();
        Task<ActionResult<Client>> FindClient(int clientId);
        Task<IActionResult> AddClient(Client client);
        Task<ActionResult> UpdateClient(int id, Client client);
        Task<IActionResult> DeleteClient(int clientId);
    }
}