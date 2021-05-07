using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApiDataContext dc;

        public ClientRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Client>> GetClient()
        {
            return await dc.Client.ToListAsync();
        }
        public void AddClient(Client client)
        {
            dc.Client.AddAsync(client);
        }
        public void DeleteClient(int clientId)
        {
            var client = dc.Client.Find(clientId);
            dc.Client.Remove(client);
        }
        public async Task UpdateClient(Client client)
        {
            dc.Entry(client).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Client> FindClient(int clientId)
        {
            return await dc.Client.FindAsync(clientId);
        }
    }
}