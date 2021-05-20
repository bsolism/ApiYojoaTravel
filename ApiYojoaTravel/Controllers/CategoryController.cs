using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiYojoaTravel.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork uow;
        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;

        }
         [HttpGet]
        public Task<IEnumerable<Category>> GetCategory()
        {
            return uow.CategoryApplication.GetCategory();
        }
        [HttpGet("{id}")]
        public Task<ActionResult<Category>> GetById(int id)
        {
            var category = uow.CategoryApplication.FindCategory(id);
            return category;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var activit = await uow.CategoryApplication.AddCategory(category);
            if (activit == null)
            {
                return BadRequest();
            }
            return Ok(activit);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var Category = await uow.CategoryApplication.UpdateCategory(id, category);
            if (Category == null)
            {
                return BadRequest();

            }
            return StatusCode(201);           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Category = await uow.CategoryApplication.DeleteCategory(id);
            if (Category == null)
            {
                return BadRequest();
            }
            return StatusCode(201);         
        }
    }
}