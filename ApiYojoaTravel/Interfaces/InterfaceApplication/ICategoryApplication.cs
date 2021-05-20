using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Interfaces
{
    public interface ICategoryApplication
    {
       Task<IEnumerable<Category>> GetCategory();
        Task<ActionResult<Category>> FindCategory(int categoryId);
        Task<IActionResult> AddCategory(Category category);
        Task<ActionResult> UpdateCategory(int id, Category category);
        Task<IActionResult> DeleteCategory(int categoryId);
    }
}