using System.Collections.Generic;
using System.Threading.Tasks;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DataContext.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDataContext dc;

        public CategoryRepository(ApiDataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await dc.Category.ToListAsync();
        }
        public void AddCategory(Category category)
        {
            dc.Category.AddAsync(category);
        }
        public void DeleteCategory(int categoryId)
        {
            var category = dc.Category.Find(categoryId);
            dc.Category.Remove(category);
        }
        public async Task UpdateCategory(Category category)
        {
            dc.Entry(category).State = EntityState.Modified;
            await dc.SaveChangesAsync();
        }
        public async Task<Category> FindCategory(int categoryId)
        {
            return await dc.Category.FindAsync(categoryId);
        }
    }
}