using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApiDataContext dc;

        public PolicyRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Policy>> GetPolicy()
        {
            return await dc.Policy.ToListAsync();
        }
        public void AddPolicy(Policy policy)
        {
            dc.Policy.AddAsync(policy);
        }
        public void DeletePolicy(int policyId)
        {
            var policy = dc.Policy.Find(policyId);
            dc.Policy.Remove(policy);
        }
        public async Task UpdatePolicy(Policy policy)
        {
            dc.Entry(policy).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Policy> FindPolicy(int policyId)
        {
            return await dc.Policy.FindAsync(policyId);
        }

    }
}