using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IUnitOfWork uow;
        public ClientController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            var Client = await uow.ClientRepository.GetClient();
            return Ok(Client);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int clientId)
        {
            return await uow.ClientRepository.FindClient(clientId);
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            uow.ClientRepository.AddClient(client);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }
            await uow.ClientRepository.UpdateClient(client);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            uow.ClientRepository.DeleteClient(clientId);
            await uow.SaveAsync();
            return Ok(clientId);
        }
    }
}