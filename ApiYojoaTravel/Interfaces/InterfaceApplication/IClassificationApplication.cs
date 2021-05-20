using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClassificationApplication
    {
       Task<IEnumerable<Classification>> GetClassification();
        Task<ActionResult<Classification>> FindClassification(int classificationId);
        Task<IActionResult> AddClassification(Classification classification);
        Task<ActionResult> UpdateClassification(int id, Classification classification);
        Task<IActionResult> DeleteClassification(int classificationId);
    }
}