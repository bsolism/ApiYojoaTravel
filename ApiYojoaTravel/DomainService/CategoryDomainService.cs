using System.Threading.Tasks;
using ApiYojoaTravel.DataContext;
using ApiYojoaTravel.Interfaces;
using ApiYojoaTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiYojoaTravel.DomainService
{
    public class CategoryDomainService : ICategoryDomainService
    {
         private readonly ApiDataContext dc;
        public CategoryDomainService(ApiDataContext dc)
        {
            this.dc = dc;

        }
        public bool PostCategory(Category Category)
        {
            bool requiredField;
            requiredField = (Category.Name == null) ? true : false;
            requiredField = (Category.Description == null) ? true : false;
            requiredField = (Category.ClassificationId == 0) ? true : false;
            return requiredField;
        }
        public async Task<ActionResult<Category>> FindCategory(int CategoryId)
        {
            var Category = await dc.Category.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);
            return Category;
        }
        public Category DomainDeleteCategory(int id)
        {
            var Category = dc.Category.Find(id);
            if (Category == null)
            {
                return null;
            }
            return Category;
        }
        
    }

}