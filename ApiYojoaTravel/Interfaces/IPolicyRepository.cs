using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
namespace ApiYojoaTravel.Interfaces
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetPolicy();
        void AddPolicy(Policy policy);
        void DeletePolicy(int policyId);
        Task UpdatePolicy(Policy policy);
        Task<Policy> FindPolicy(int policyId);
    }

}
