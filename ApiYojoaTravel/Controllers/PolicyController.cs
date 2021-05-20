using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class PolicyController : BaseController
    {
        private readonly IUnitOfWork uow;
        public PolicyController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
         [HttpGet]
        public Task<IEnumerable<Policy>> GetPolicy()
        {
            return uow.PolicyApplication.GetPolicy();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Policy>> GetById(int id)
        {
            var policy = uow.PolicyApplication.FindPolicy(id);
            return policy;
        }
        [HttpPost]
        public async Task<IActionResult> AddPolicy(Policy policy)
        {
            var activit = await uow.PolicyApplication.AddPolicy(policy);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            var Policy = await uow.PolicyApplication.UpdatePolicy(id, policy);
            if (Policy == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var Policy = await uow.PolicyApplication.DeletePolicy(id);
            if (Policy == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}