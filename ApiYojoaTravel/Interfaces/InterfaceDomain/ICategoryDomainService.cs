using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface ICategoryDomainService
    {
        bool PostCategory(Category Category);
        Task<ActionResult<Category>> FindCategory(int CategoryId);
        Category DomainDeleteCategory(int id);
        
    }
}