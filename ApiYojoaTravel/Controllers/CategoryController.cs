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
        public async Task<IActionResult> GetCategory()
        {
            var Category = await uow.CategoryRepository.GetCategory();
            return Ok(Category);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int categoryId)
        {
            return await uow.CategoryRepository.FindCategory(categoryId);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            uow.CategoryRepository.AddCategory(category);
            await uow.SaveAsync();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }
            await uow.CategoryRepository.UpdateCategory(category);
            return StatusCode(201);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            uow.CategoryRepository.DeleteCategory(categoryId);
            await uow.SaveAsync();
            return Ok(categoryId);
        }
    }
}