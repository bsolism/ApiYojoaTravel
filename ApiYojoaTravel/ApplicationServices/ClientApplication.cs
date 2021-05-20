using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class ClientApplication: IClientApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public ClientApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Client>> GetClient()
        {
            return await dc.Client.ToListAsync();
        }
        public Task<ActionResult<Client>> FindClient(int ClientId)
        {
            var Client = uow.ClientDomainService.FindClient(ClientId);
            if (Client != null)
            {
                return Client;
            }
            return null;

        }
        public async Task<IActionResult> AddClient(Client Client)
        {
            var RequiredField = uow.ClientDomainService.PostClient(Client);
            if (!RequiredField)
            {
                dc.Client.Add(Client);
                await dc.SaveChangesAsync();
                return new ObjectResult(Client);
            }
            return null;
        }
        public async Task<ActionResult> UpdateClient(int id, Client Client)
        {
            if (id != Client.ClientId)
            {
                return null;

            }
            dc.Entry(Client).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteClient(int ClientId)
        {
            var Client = uow.ClientDomainService.DomainDeleteClient(ClientId);
            if (Client == null)
            {
                return null;
            }
            dc.Client.Remove(Client);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}