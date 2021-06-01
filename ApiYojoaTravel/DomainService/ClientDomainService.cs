using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class ClientDomainService: IClientDomainService
    {
         private readonly ApiDataContext dc;
        public ClientDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostClient(Client Client)
        {
            bool requiredField;
            requiredField = (Client.Name == null) ? true : false;
            requiredField = (Client.DNI == null) ? true : false;
            requiredField = (Client.Age == 0) ? true : false;
            requiredField = (Client.Sex == null) ? true : false;
            requiredField = (Client.OriginCity == null) ? true : false;
            requiredField = (Client.phoneNumber == null) ? true : false;
            return requiredField;
        }          
        public async Task<ActionResult<Client>> FindClient(int ClientId)
        {
            var Client = await dc.Client.FirstOrDefaultAsync(x => x.ClientId == ClientId);
            return Client;
        }
        public Client DomainDeleteClient(int id)
        {
            var Client = dc.Client.Find(id);
            if (Client == null)
            {
                return null;
            }
            return Client;
        }
        
    }
}