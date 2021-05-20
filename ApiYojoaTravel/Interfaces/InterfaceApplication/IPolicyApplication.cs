using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPolicyApplication
    {
       Task<IEnumerable<Policy>> GetPolicy();
        Task<ActionResult<Policy>> FindPolicy(int policyId);
        Task<IActionResult> AddPolicy(Policy policy);
        Task<ActionResult> UpdatePolicy(int id, Policy policy);
        Task<IActionResult> DeletePolicy(int policyId);
    }
}