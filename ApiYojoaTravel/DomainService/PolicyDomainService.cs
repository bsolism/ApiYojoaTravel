using System;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class PolicyDomainService: IPolicyDomainService
    {
        private readonly ApiDataContext dc;
        public PolicyDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostPolicy(Policy Policy)
        {
            bool requiredField;
            requiredField = (Policy.PolicyName ==  null) ? true : false;
            requiredField = (Policy.Description == null) ? true : false;
            requiredField = (Policy.CancellationDeadlineHours == 0) ? true : false;
            return requiredField;
        }    
         
       
        public async Task<ActionResult<Policy>> FindPolicy(int PolicyId)
        {
            var Policy = await dc.Policy.FirstOrDefaultAsync(x => x.PolicyId == PolicyId);
            return Policy;
        }
        public Policy DomainDeletePolicy(int id)
        {
            var Policy = dc.Policy.Find(id);
            if (Policy == null)
            {
                return null;
            }
            return Policy;
        }
        
    }
}