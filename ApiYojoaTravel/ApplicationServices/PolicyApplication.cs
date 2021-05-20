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
    public class PolicyApplication: IPolicyApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public PolicyApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Policy>> GetPolicy()
        {
            return await dc.Policy.ToListAsync();
        }
        public Task<ActionResult<Policy>> FindPolicy(int PolicyId)
        {
            var Policy = uow.PolicyDomainService.FindPolicy(PolicyId);
            if (Policy != null)
            {
                return Policy;
            }
            return null;

        }
        public async Task<IActionResult> AddPolicy(Policy Policy)
        {
            var RequiredField = uow.PolicyDomainService.PostPolicy(Policy);
            if (!RequiredField)
            {
                dc.Policy.Add(Policy);
                await dc.SaveChangesAsync();
                return new ObjectResult(Policy);
            }
            return null;
        }
        public async Task<ActionResult> UpdatePolicy(int id, Policy Policy)
        {
            if (id != Policy.PolicyId)
            {
                return null;

            }
            dc.Entry(Policy).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeletePolicy(int PolicyId)
        {
            var Policy = uow.PolicyDomainService.DomainDeletePolicy(PolicyId);
            if (Policy == null)
            {
                return null;
            }
            dc.Policy.Remove(Policy);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}