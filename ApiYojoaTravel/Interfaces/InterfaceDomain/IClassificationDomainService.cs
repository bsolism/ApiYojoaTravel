using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface IClassificationDomainService
    {
        bool PostClassification(Classification Classification);
        Task<ActionResult<Classification>> FindClassification(int ClassificationId);
        Classification DomainDeleteClassification(int id);
    }
}