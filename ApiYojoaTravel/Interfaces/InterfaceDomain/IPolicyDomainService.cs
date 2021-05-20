using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IPolicyDomainService
    {
        bool PostPolicy(Policy Policy);
        Task<ActionResult<Policy>> FindPolicy(int PolicyId);
        Policy DomainDeletePolicy(int id);
    }
}