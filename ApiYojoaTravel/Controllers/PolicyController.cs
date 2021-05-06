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
        public async Task<IActionResult> GetPolicy()
        {
            var Policy = await uow.PolicyRepository.GetPolicy();
            return Ok(Policy);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicyById(int policyId)
        {
            return await uow.PolicyRepository.FindPolicy(policyId);
        }
        [HttpPost]
        public async Task<IActionResult> AddPolicy(Policy policy)
        {
            uow.PolicyRepository.AddPolicy(policy);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return BadRequest();
            }
            await uow.PolicyRepository.UpdatePolicy(policy);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int policyId)
        {
            uow.PolicyRepository.DeletePolicy(policyId);
            await uow.SaveAsync();
            return Ok(policyId);
        }

    }
}