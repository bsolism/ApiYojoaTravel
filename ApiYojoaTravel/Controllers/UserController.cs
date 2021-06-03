using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;
        public UserController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
         [HttpGet]
        public Task<IEnumerable<User>> GetUser()
        {
            return uow.UserApplication.GetUser();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<User>> GetById(int id)
        {
            var User = uow.UserApplication.FindUser(id);
            return User;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User User)
        {
            var activit = await uow.UserApplication.AddUser(User);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User User)
        {
            var user = await uow.UserApplication.UpdateUser(id, User);
            if (user == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await uow.UserApplication.DeleteUser(id);
            if (User == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}