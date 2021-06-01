using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.DomainService;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.ApplicationServices
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ApiDataContext dc;
        private readonly IDomainUnitOfWork uow;
        public CategoryApplication(ApiDataContext dc, IDomainUnitOfWork uow)
        {
            this.uow = uow;
            this.dc = dc;

        }
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await dc.Category.ToListAsync();
        }
        public Task<ActionResult<Category>> FindCategory(int CategoryId)
        {
            var Category = uow.CategoryDomainService.FindCategory(CategoryId);
            if (Category != null)
            {
                return Category;
            }
            return null;

        }
        public async Task<IActionResult> AddCategory(Category Category)
        {
            var RequiredField = uow.CategoryDomainService.PostCategory(Category);
            if (!RequiredField)
            {
                dc.Category.Add(Category);
                await dc.SaveChangesAsync();
                return new ObjectResult(Category);
            }
            return null;
        }
        public async Task<ActionResult> UpdateCategory(int id, Category Category)
        {
            if (id != Category.CategoryId)
            {
                return null;

            }
            dc.Entry(Category).State = EntityState.Modified;
            var res = await dc.SaveChangesAsync();
            return new ObjectResult(res);
        }
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var Category = uow.CategoryDomainService.DomainDeleteCategory(CategoryId);
            if (Category == null)
            {
                return null;
            }
            dc.Category.Remove(Category);
            await dc.SaveChangesAsync();
            return new ObjectResult(1);
        }
    }
}