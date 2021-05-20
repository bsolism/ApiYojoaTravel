using System.Collections.Generic;
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
        public Task<IEnumerable<Client>> GetClient()
        {
            return uow.ClientApplication.GetClient();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Client>> GetById(int id)
        {
            var client = uow.ClientApplication.FindClient(id);
            return client;
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            var activit = await uow.ClientApplication.AddClient(client);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            var Client = await uow.ClientApplication.UpdateClient(id, client);
            if (Client == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var Client = await uow.ClientApplication.DeleteClient(id);
            if (Client == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}