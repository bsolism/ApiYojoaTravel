using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClientDomainService
    {
        bool PostClient(Client Client);
        Task<ActionResult<Client>> FindClient(int ClientId);
        Client DomainDeleteClient(int id);
    }
}