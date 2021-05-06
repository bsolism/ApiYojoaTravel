using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClassificationRepository
    {

        Task<IEnumerable<Classification>> GetClassification();
        void AddClassification(Classification classification);
        void DeleteClassification(int classificationId);
        Task UpdateClassification(Classification classification);
        Task<Classification> FindClassification(int classificationId);
    }
}